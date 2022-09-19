using Microsoft.AspNetCore.Identity;

namespace DriveMoto.Models
{
    public class User : IdentityUser
    {
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public int Phone { get; set; }

        public string? Email { get; set; }

        public List<CartItem>? CartItems { get; set; }

        public List<Favorite>? Favorites { get; set; }
    }
}
