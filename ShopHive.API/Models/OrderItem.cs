using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [InverseProperty("OrderItems")]
        public Order Order { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [InverseProperty("OrderItems1")]
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal UnitPrice { get; set; }
    }
}
