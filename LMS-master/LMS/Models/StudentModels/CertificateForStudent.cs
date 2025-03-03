using LMS.Models.InstractourModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.StudentModels
{
    public class CertificateForStudent
    {
        [Key] //surrougate 
        public int Id { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [ForeignKey("Student")]

        public string StudentId { get; set; }
        public AppUser Student { get; set; }

        [Required]
        public DateTime AcquireDate { get; set; }

        [Required]
        public string Grade { get; set; }
    }
}
