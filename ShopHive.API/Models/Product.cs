using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Price { get; set; }
        public decimal VATPercent { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [InverseProperty("Products")]
        public Category Category { get; set; }
    }
}
