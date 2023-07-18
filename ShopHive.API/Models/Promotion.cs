using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Promotion
    {
        public int Id { get; set; }
        public string CouponCode { get; set; }
        public decimal DiscountPercent { get; set; }
        public bool IsActive { get; set; }
        public DateTime ExpiryDate { get; set; }

        
        public int ProductId { get; set; }

        
        public Product Product { get; set; }
    }
}
