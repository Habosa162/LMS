using LMS.Models;
using LMS.Models.InstractourModel;
using LMS.Models.StudentModels;

public interface IStudentRepository
{
    // Course-related actions
    IEnumerable<Course> GetAllCourses();
    IEnumerable<Course> SearchCoursesByName(string name);
    IEnumerable<Course> SearchCoursesByCategory(Category category);
    IEnumerable<Course> GetRecommendedCourses(string studentId);

    // Certificate actions
    CertificateForStudent GetCertificateForCourse(string studentId, int courseId);
    bool CheckCourseCompletion(string studentId, int courseId);
    IEnumerable<CertificateForStudent> GetAllCertificates(string studentId);

    // Notes management
    void AddNoteToLesson(string studentId, int lessonId, string content);
    IEnumerable<Note> GetAllNotes(string studentId);
    void UpdateNote(int noteId, string newContent);
    void DeleteNote(int noteId);

    // Purchase management
    void PurchaseCourse(string studentId, int courseId);
    IEnumerable<Purchase> GetAllPurchases(string studentId);

    // Review & Rating management
    void AddReview(string studentId, int courseId, string reviewText, int rating);
    void UpdateReview(int reviewId, string newReviewText, int newRating);
    void DeleteReview(int reviewId);
    IEnumerable<ReviewedCourse> GetAllReviews(int courseId);

    // Enrollment management
    IEnumerable<Course> GetEnrolledCourses(string studentId);
    void EnrollInCourse(string studentId, int courseId);
    void RemoveEnrollment(string studentId, int courseId);

    // Lesson progress tracking
    IEnumerable<Lesson> GetAllLessonsInCourse(int courseId);
    void MarkLessonAsStudied(string studentId, int lessonId);
    double GetCourseProgress(string studentId, int courseId);

    // Wishlist management
    void AddToWishlist(string studentId, int courseId);
    IEnumerable<Course> GetWishlist(string studentId);
    void RemoveFromWishlist(string studentId, int courseId);
}
