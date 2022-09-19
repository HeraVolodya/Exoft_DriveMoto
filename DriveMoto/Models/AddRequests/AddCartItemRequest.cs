using System.ComponentModel.DataAnnotations;

namespace DriveMoto.Models.AddRequest
{
    public class AddCartItemRequest
    {
        [Required]
        public string? UserId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        
    }
}
