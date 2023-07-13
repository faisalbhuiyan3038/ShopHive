using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Review
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }

        [InverseProperty("Reviews")]
        public User User { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        [InverseProperty("Reviews1")]
        public Product Product { get; set; }

        public int Rating { get; set; }
        public string? Comment { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
