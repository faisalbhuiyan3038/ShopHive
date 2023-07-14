using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class CartProduct
    {
        public int Id { get; set; }

        [ForeignKey("Cart")]
        public int CartId { get; set; }

        [InverseProperty("Carts")]
        public Cart Cart { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [InverseProperty("CartProducts")]
        public Product Product { get; set; } 

        public int Quantity { get; set; }
    }
}
