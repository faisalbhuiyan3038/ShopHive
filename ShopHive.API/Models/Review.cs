using ShopHive.API.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Review
    {
        public int Id { get; set; }

       public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }

        
        public int ProductId { get; set; }

        
        public Product Product { get; set; }

        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
