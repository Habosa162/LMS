using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    public class StudentStudiedLesson
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public AppUser Student { get; set; }

        [ForeignKey("Lesson")]

        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
    }
}
