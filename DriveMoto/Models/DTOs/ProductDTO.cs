using System.ComponentModel.DataAnnotations;

namespace DriveMoto.Models.DTOs
{
    public class ProductDTO
    {
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
    }
}
