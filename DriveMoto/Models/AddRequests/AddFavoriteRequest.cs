using System.ComponentModel.DataAnnotations;

namespace DriveMoto.Models.AddRequests
{
    public class AddFavoriteRequest
    {
        [Required]
        public string? UserId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
    }
}
