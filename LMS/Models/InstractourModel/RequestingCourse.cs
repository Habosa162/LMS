using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.InstractourModel
{
    public class RequestingCourse
    {
        [Key]
        public int Id { get; set; }


        [ForeignKey("Course")]
        public int CourseId { get; set; }
        public Course Course { get; set; }

        [ForeignKey("RequestedCourse")]
        public int RequestedCourseId { get; set; }
        public Course RequestedCourse { get; set; }

    }
}
