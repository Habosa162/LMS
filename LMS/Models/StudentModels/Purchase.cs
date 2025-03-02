using LMS.Models.InstractourModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace LMS.Models.StudentModels
{
    public class Purchase
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public AppUser Student { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        public DateTime PurchaseDate { get; set; } = DateTime.Now;

        public decimal AmountPaid { get; set; }
    }
}
