namespace ShopHive.API.Models.DTO
{
    public class AddCategoryRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted = false;
    }
}
