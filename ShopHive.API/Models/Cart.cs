using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Cart
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [InverseProperty("Carts")]
        public User User { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
