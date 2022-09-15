using System.ComponentModel.DataAnnotations;

namespace DriveMoto.Models.DTOs
{
    public class CartItemDTO
    {
        [Required]
        public Guid CleantId { get; set; }
        [Required]
        public Guid ProductId { get; set; }

        public ClientDTO? Client { get; set; }

        public ProductDTO? Product { get; set; }
    }
}
