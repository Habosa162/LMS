using Microsoft.AspNetCore.Identity;

namespace LMS.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }

        string ProfileImg {  get; set; }



     
    }
}
