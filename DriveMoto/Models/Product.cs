using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DriveMoto.Models
{
    public class Product
    {
        [Required]
        public Guid Id { get; set; }
        [Required] //атрибут [Required] вказує на те що поля повині бути
                   //обовязково заповненими
        public DateTimeOffset DataTime { get; set; } = DateTimeOffset.Now;
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? ImageURL { get; set; }
        [Required]
        public int СodeProduct { get; set; }
        [Required]
        public string? Сategory { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public double Discount { get; set; }

        public List<CartItem>? CartItems { get; set; }

        public List<Favorite>? Favorites { get; set; }
    }
}
