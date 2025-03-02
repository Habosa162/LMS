using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models.InstractourModel
{
    public class Chapter
    {
        public int ID { get; set; }

        public string Name { get; set; }    

        public string Title { get; set; }

        [ForeignKey("Course")]
        public int CourseID { get; set; }
        public Course Course { get; set; }


        public ICollection<Lesson> Lessons { get; set; } = new List<Lesson>();


    }
}
