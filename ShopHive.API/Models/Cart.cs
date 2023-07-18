using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Cart
    {
        public int Id { get; set; }

        
        public int UserId { get; set; }

        
        public User User { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
