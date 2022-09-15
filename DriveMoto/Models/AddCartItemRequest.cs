using System.ComponentModel.DataAnnotations;

namespace DriveMoto.Models
{
    public class AddCartItemRequest
    {
        [Required]
        public Guid CleantId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
    }
}
