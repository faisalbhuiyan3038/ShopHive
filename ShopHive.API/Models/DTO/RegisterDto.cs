using System.ComponentModel.DataAnnotations;

namespace ShopHive.API.Models.DTO
{
    public class RegisterDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,13}$", ErrorMessage = "Password requires one lowercase letter, one uppercase letter, one digit, 6-13 length.")]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Mobile { get; set; }
        [Required]
        public string? Address { get; set; }
    }
}
