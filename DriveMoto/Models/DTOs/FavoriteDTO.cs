namespace DriveMoto.Models.DTOs
{
    public class FavoriteDTO
    {
        public string? UserId { get; set; }

        public Guid ProductId { get; set; }

        public UserDTO? User { get; set; }

        public ProductDTO? Product { get; set; }
    }
}
