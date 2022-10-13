using System.ComponentModel.DataAnnotations;

namespace Week_3.Models
{
    public class User
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [MinLength(1)]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        public string Email { get; set; }

        [Required]
        [Range(1, 150)]
        public int Age { get; set; }
    }
}
