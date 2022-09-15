using System.ComponentModel.DataAnnotations;

namespace DriveMoto.Models.UpdateRequests
{
    public class UpdateCartItemRequest
    {
        [Required]
        public Guid CleantId { get; set; }
        [Required]
        public Guid ProductId { get; set; }

        public Client? Client { get; set; }

        public Product? Product { get; set; }
    }
}
