using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.InstractourModel
{
    public class RequestingCourse
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Instructor")]
        public string InstructorID { get; set; }
        public AppUser Instructor { get; set; }



        [ForeignKey("RequestedCourse")]
        public int RequestedCourseId { get; set; }
        public Course RequestedCourse { get; set; }

    }
}
