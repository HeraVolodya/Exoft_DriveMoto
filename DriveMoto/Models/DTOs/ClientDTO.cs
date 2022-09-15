using System.ComponentModel.DataAnnotations;

namespace DriveMoto.Models.DTOs
{
    public class ClientDTO
    {
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public int Phone { get; set; }
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
