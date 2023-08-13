
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Wishlist
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        
        public int ProductId { get; set; }

        
        public Product Product { get; set; }
    }
}
