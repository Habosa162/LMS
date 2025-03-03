using LMS.Models.InstractourModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models.StudentModels
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("Lesson")]
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public AppUser Student { get; set; }
    }
}
