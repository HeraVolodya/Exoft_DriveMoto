using System.ComponentModel.DataAnnotations;

namespace DriveMoto.Models
{
    public class CartItem
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTimeOffset DataTime { get; set; } = DateTimeOffset.Now;
        [Required]
        public Guid CleantId { get; set; }
        [Required]
        public Guid ProductId { get; set; }
        
        public Client? Client { get; set; }
        
        public Product? Product { get; set; }
    }
}
