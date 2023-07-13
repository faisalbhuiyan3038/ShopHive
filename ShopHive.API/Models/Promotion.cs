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

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [InverseProperty("Promotions")]
        public Product Product { get; set; }
    }
}
