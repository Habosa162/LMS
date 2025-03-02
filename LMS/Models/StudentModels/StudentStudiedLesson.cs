using LMS.Models.InstractourModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.StudentModels
{
    public class StudentStudiedLesson
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }
        
        [ForeignKey("Lesson")]
        public int LessonId { get; set; }

        public AppUser Student { get; set; }
        public Lesson Lesson { get; set; }
    }
}
