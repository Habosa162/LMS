using LMS.Models.InstractourModel;
using LMS.Models.StudentModels;
using Microsoft.AspNetCore.Identity;

namespace LMS.Models
{
    public class AppUser : IdentityUser
    {
        public string Name { get; set; }
        public string ProfileImg { get; set; }

        public ICollection<StudentEnrollCourse> EnrolledCourses { get; set; } = new List<StudentEnrollCourse>();
        public ICollection<Purchase> Purchases { get; set; } = new List<Purchase>();
    }
}
