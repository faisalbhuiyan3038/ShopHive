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
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?!.*\\s).{4,8}$", ErrorMessage = "Password requires one lower case letter, one upper case letter, one digit, 6-13 length, and no spaces.")]
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
