using System.ComponentModel.DataAnnotations;

namespace Academy_2025.Data
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Name { get; set; }   //<--- Név hozzáadás

        [Required]
        public int Age { get; set; }

        [Required]
        public string? Role { get; set; } //Role hozzáadás

        public ICollection<Course> Courses { get; set; } = [];
    }
}
