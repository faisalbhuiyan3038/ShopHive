using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Payment
    {
        public int Id { get; set; }

        
        public int OrderId { get; set; }

        
        public Order Order { get; set; }

        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
    }
}
