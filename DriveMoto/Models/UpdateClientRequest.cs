using System.ComponentModel.DataAnnotations;

namespace DriveMoto.Models
{
    public class UpdateClientRequest
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
