using System.ComponentModel.DataAnnotations;

namespace DriveMoto.Models.DTOs
{
    public class CartItemDTO
    {
        public string? UserId { get; set; }

        public Guid ProductId { get; set; }

        public UserDTO? User { get; set; }

        public ProductDTO? Product { get; set; }
    }
}
