//using System.ComponentModel;
//using System.ComponentModel.DataAnnotations;
//using System.Data;

//namespace DriveMoto.Models
//{
//    public class Client
//    {
//        [Required]
//        public Guid Id { get; set; }
//        [Required]
//        public DateTimeOffset DataTime { get; set; } = DateTimeOffset.Now;
//        [Required]
//        public string? FirstName { get; set; }
//        [Required] 
//        public string? LastName { get; set; }
//        [Required]
//        public int Phone { get; set; }
//        [EmailAddress]
//        public string? Email { get; set; }
//        [Required]
//        public string? Password { get; set; }

//        public List<CartItem> CartItems { get; set; }
//    }
//}
