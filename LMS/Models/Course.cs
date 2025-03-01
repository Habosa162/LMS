using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required, StringLength(500)]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [NotMapped] // Derived attribute
        public int TotalDuration => Lessons.Sum(l => (int)l.Duration.TotalMinutes);

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public AppUser User { get; set; }
        [Required]
        public bool IsAccepted { get; set; } = false;

        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
