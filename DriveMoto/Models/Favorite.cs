using System.ComponentModel.DataAnnotations;

namespace DriveMoto.Models
{
    public class Favorite
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTimeOffset DataTime { get; set; } = DateTimeOffset.Now;
        [Required]
        public string? UserId { get; set; }
        [Required]
        public Guid ProductId { get; set; }

        public User? User { get; set; }

        public Product? Product { get; set; }
    }
}
