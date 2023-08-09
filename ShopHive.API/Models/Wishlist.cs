using ShopHive.API.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Wishlist
    {
        public int Id { get; set; }

        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        
        public string ProductId { get; set; }

        
        public Product Product { get; set; }
    }
}
