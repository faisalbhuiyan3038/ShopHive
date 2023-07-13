using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime OrderDate { get; set; }
        public string Status { get; set; }

        public decimal TotalAmount { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [InverseProperty("Orders")]
        public Product Product { get; set; }


    }
}
