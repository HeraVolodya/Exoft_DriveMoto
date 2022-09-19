using System.ComponentModel.DataAnnotations;

namespace DriveMoto.Models.UpdateRequests
{
    public class UpdateFavoriteRequest
    {
        [Required]
        public string? UserId { get; set; }
        [Required]
        public Guid ProductId { get; set; }

        public User? User { get; set; }

        public Product? Product { get; set; }
    }
}
