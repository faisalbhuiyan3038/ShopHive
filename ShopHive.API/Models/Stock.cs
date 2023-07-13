using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [InverseProperty("Stocks")]
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
