using System.ComponentModel.DataAnnotations;

namespace LMS.Models
{
    public class Category
    {
        //test mostafa

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
