using System.ComponentModel.DataAnnotations;

namespace Academy_2025.Data
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string? Name { get; set; }

        [Required]
        [StringLength(50)]
        public string? Description { get; set; }

        [Required]
        [StringLength(50)]
        public string? Author { get; set; } //Hozzáadott Author mező

        public ICollection<User> Users { get; set; } = [];
    }
}
