using Microsoft.EntityFrameworkCore;

namespace ShopHive.API.Models
{
    public class AdminUser
    {
        public int Id { get; set; }
        
        public string email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }
}
