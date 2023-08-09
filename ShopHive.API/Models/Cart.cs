using ShopHive.API.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Cart
    {
        public int Id { get; set; }

        
        public string AppUserId { get; set; }

        
        public AppUser AppUser { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
