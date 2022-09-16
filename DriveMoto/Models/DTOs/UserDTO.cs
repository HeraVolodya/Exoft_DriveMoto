using Microsoft.AspNetCore.Identity;

namespace DriveMoto.Models.DTOs
{
    public class UserDTO
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Phone { get; set; }

        public string? Email { get; set; }
    }
}
