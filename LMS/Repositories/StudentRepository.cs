using LMS.Data;
using LMS.Models;
using LMS.Models.InstractourModel;
using LMS.Models.StudentModels;
using System;

public class StudentRepository : IStudentRepository
{
    private readonly ApplicationDbContext _context;

    public StudentRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Course> GetAllCourses()
    {
        return _context.Courses.ToList();
    }
    public IEnumerable<Course> GetRecommendedCourses(string studentId)
    {
        var completedCourses = _context.StudentStudiedLessons
            .Where(s => s.StudentId == studentId)
            .Select(s => s.Lesson.Chapter.Course)
            .Distinct()
            .ToList();

        var categories = completedCourses.Select(c => c.Category).Distinct();

        return _context.Courses.Where(c => categories.Contains(c.Category) &&
                                           !completedCourses.Contains(c))
                               .Take(5)  // Limit to 5 recommendations
                               .ToList();
    }


    public IEnumerable<Course> SearchCoursesByName(string name)
    {
        return _context.Courses.Where(c => c.Name.Contains(name)).ToList();
    }

    public IEnumerable<Course> SearchCoursesByCategory(Category category)
    {
        return _context.Courses.Where(c => c.Category == category).ToList();
    }

    public CertificateForStudent GetCertificateForCourse(string studentId, int courseId)
    {
        bool completed = _context.StudentStudiedLessons
            .Where(s => s.StudentId == studentId && s.Lesson.Id == courseId)
            .Count() == _context.Lessons.Count(l => l.Id == courseId);

        if (completed)
        {
            var certificate = new CertificateForStudent
            {
                StudentId = studentId,
                CourseId = courseId,
                AcquireDate = DateTime.Now
            };
            _context.Certificates.Add(certificate);
            _context.SaveChanges();
            return certificate;
        }
        return null;
    }
    public bool CheckCourseCompletion(string studentId, int courseId)
    {
        int totalLessons = _context.Lessons.Count(l => l.Chapter.CourseID == courseId);
        int completedLessons = _context.StudentStudiedLessons
            .Count(s => s.StudentId == studentId && s.Lesson.Chapter.CourseID == courseId);

        if (completedLessons == totalLessons && totalLessons > 0)
        {
            GetCertificateForCourse(studentId, courseId);
            return true; // Course completed
        }
        return false;
    }

    public IEnumerable<CertificateForStudent> GetAllCertificates(string studentId)
    {
        return _context.Certificates.Where(c => c.StudentId == studentId).ToList();
    }

    public void AddNoteToLesson(string studentId, int lessonId, string content)
    {
        var note = new Note
        {
            StudentId = studentId,
            LessonId = lessonId,
            Content = content,
            CreatedAt = DateTime.Now
        };
        _context.Notes.Add(note);
        _context.SaveChanges();
    }

    public IEnumerable<Note> GetAllNotes(string studentId)
    {
        return _context.Notes.Where(n => n.StudentId == studentId).ToList();
    }

    public void UpdateNote(int noteId, string newContent)
    {
        var note = _context.Notes.Find(noteId);
        if (note != null)
        {
            note.Content = newContent;
            _context.SaveChanges();
        }
    }

    public void DeleteNote(int noteId)
    {
        var note = _context.Notes.Find(noteId);
        if (note != null)
        {
            _context.Notes.Remove(note);
            _context.SaveChanges();
        }
    }

    public void PurchaseCourse(string studentId, int courseId)
    {
        var payment = new Purchase
        {
            StudentId = studentId,
            CourseId = courseId,
            PurchaseDate = DateTime.Now,
            AmountPaid = _context.Courses.Find(courseId)?.Price ?? 0
        };
        _context.Purchases.Add(payment);
        _context.SaveChanges();

        EnrollInCourse(studentId, courseId);
    }

    public IEnumerable<Purchase> GetAllPurchases(string studentId)
    {
        return _context.Purchases.Where(p => p.StudentId == studentId).ToList();
    }

    public void AddReview(string studentId, int courseId, string reviewText, int rating)
    {
        var review = new ReviewedCourse
        {
            StudentId = studentId,
            CourseId = courseId,
            Comment = reviewText,
            Rating = rating,
            DateTime = DateTime.Now
        };
        _context.ReviewedCourses.Add(review);
        _context.SaveChanges();
    }

    public void UpdateReview(int reviewId, string newReviewText, int newRating)
    {
        var review = _context.ReviewedCourses.Find(reviewId);
        if (review != null)
        {
            review.Comment = newReviewText;
            review.Rating = newRating;
            _context.SaveChanges();
        }
    }

    public void DeleteReview(int reviewId)
    {
        var review = _context.ReviewedCourses.Find(reviewId);
        if (review != null)
        {
            _context.ReviewedCourses.Remove(review);
            _context.SaveChanges();
        }
    }

    public IEnumerable<ReviewedCourse> GetAllReviews(int courseId)
    {
        return _context.ReviewedCourses.Where(r => r.CourseId == courseId).ToList();
    }

    public IEnumerable<Course> GetEnrolledCourses(string studentId)
    {
        return _context.studentEnrollCourses.Where(sc => sc.StudentId == studentId)
            .Select(sc => sc.Course).ToList();
    }

    public void EnrollInCourse(string studentId, int courseId)
    {
        if (!_context.studentEnrollCourses.Any(sc => sc.StudentId == studentId && sc.CourseId == courseId))
        {
            _context.studentEnrollCourses.Add(new StudentEnrollCourse { StudentId = studentId, CourseId = courseId });
            _context.SaveChanges();
        }
    }

    public void RemoveEnrollment(string studentId, int courseId)
    {
        var enrollment = _context.studentEnrollCourses.FirstOrDefault(sc => sc.StudentId == studentId && sc.CourseId == courseId);
        if (enrollment != null)
        {
            _context.studentEnrollCourses.Remove(enrollment);
            _context.SaveChanges();
        }
    }

    public IEnumerable<Lesson> GetAllLessonsInCourse(int courseId)
    {
        return _context.Lessons.Where(l => l.ChapterID == courseId).ToList();
    }

    public void MarkLessonAsStudied(string studentId, int lessonId)
    {
        _context.StudentStudiedLessons.Add(new StudentStudiedLesson { StudentId = studentId, LessonId = lessonId });
        _context.SaveChanges();
    }

    public double GetCourseProgress(string studentId, int courseId)
    {
        int totalLessons = _context.Lessons.Count(l => l.Chapter.CourseID == courseId);
        int completedLessons = _context.StudentStudiedLessons
            .Count(s => s.StudentId == studentId && s.Lesson.Chapter.CourseID == courseId);

        return totalLessons > 0 ? (completedLessons / (double)totalLessons) * 100 : 0;
    }

    public void AddToWishlist(string studentId, int courseId)
    {
        _context.WishList.Add(new WishList { StudentId = studentId, WishedCourseId = courseId });
        _context.SaveChanges();
    }

    public IEnumerable<Course> GetWishlist(string studentId)
    {
        return _context.WishList.Where(w => w.StudentId == studentId).Select(w => w.WishedCourse).ToList();
    }

    public void RemoveFromWishlist(string studentId, int courseId)
    {
        var item = _context.WishList.FirstOrDefault(w => w.StudentId == studentId && w.WishedCourseId == courseId);
        if (item != null)
        {
            _context.WishList.Remove(item);
            _context.SaveChanges();
        }
    }
}
