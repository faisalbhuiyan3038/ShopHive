using System.ComponentModel.DataAnnotations;

namespace ShopHive.API.Models.DTO
{
    public class AdminUserDto
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
