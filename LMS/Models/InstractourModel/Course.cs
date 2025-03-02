using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.InstractourModel
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Name { get; set; }

        [Required, StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(10,5000)]
        public decimal Price { get; set; }

        [NotMapped] // Derived attribute
        public int TotalDuration => Lessons.Sum(l => (int)l.Duration.TotalMinutes);

        public string Image { get; set; }
        public bool IsAccepted { get; set; } = false;
        public bool IsDeleted { get; set; } = false;


        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        
        [ForeignKey("Teacher")]
        public int TeacherId { get; set; }


        public Category Category { get; set; }
        public AppUser Teacher { get; set; }
        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();
    }
}
