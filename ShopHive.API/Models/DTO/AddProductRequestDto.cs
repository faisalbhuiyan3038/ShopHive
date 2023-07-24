namespace ShopHive.API.Models.DTO
{
    public class AddProductRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted = false;
        public decimal Price { get; set; }
        public string ProductImageUrl { get; set; }


        public string CategoryName { get; set; }
    }
}
