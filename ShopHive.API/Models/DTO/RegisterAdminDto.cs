using System.ComponentModel.DataAnnotations;

namespace ShopHive.API.Models.DTO
{
    public class RegisterAdminDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,13}$", ErrorMessage = "Password requires one lowercase letter, one uppercase letter, one digit, 6-13 length.")]
        public string Password { get; set; }
        
    }
}
