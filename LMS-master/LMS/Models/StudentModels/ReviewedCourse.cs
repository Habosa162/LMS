using LMS.Models.InstractourModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.StudentModels
{
    public class ReviewedCourse
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public AppUser Student { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [StringLength(250)]
        public string Comment { get; set; }

        [Required, Range(0, 5)]
        public decimal Rating { get; set; }

        [Required]
        public DateTime DateTime { get; set; }
    }
}
