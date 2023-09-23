using System.ComponentModel.DataAnnotations;

namespace ShopHive.API.Models.DTO
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "Invalid Price Amount")]
        public decimal Price { get; set; }
        [Required]
        [Range (1, double.MaxValue, ErrorMessage = "Invalid Quantity")]
        public int Quantity { get; set; }
        [Required]
        public string PictureUrl { get; set; }
        [Required]
        public string Category { get; set; }
    }
}
