using System.ComponentModel.DataAnnotations;

namespace DriveMoto.Models.DTOs
{
    public class AdvertisementDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public DateTimeOffset DataTime { get; set; } = DateTimeOffset.Now;
        [Required]
        public string? Text { get; set; }

        public string? ImageURL { get; set; }
    }
}
