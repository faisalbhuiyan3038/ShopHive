using System.ComponentModel.DataAnnotations.Schema;

namespace ShopHive.API.Models
{
    public class Product:BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public decimal Price { get; set; }
        public string ProductImageUrl { get; set; }

        
        public int CategoryId { get; set; }

        
        public Category Category { get; set; }
    }
}
