using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Wishlist
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [InverseProperty("WishlistUsers")]
        public User User { get; set; }

        [ForeignKey("Product")]
        public string ProductId { get; set; }

        [InverseProperty("WishlistsProducts")]
        public Product Product { get; set; }
    }
}
