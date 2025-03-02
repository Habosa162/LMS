using LMS.Models.InstractourModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.StudentModels
{
    public class WishList
    {

        [Key]
        public int Id { get; set; }

        [ForeignKey("Student")]
        public string StudentId { get; set; }
        public AppUser Student { get; set; }

        [ForeignKey("WishedCourse")]
        public int WishedCourseId { get; set; }
        public Course WishedCourse { get; set; }
    }
}
