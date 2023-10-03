namespace ShopHive.API.Models.OrderAggregate
{
    public class ProductItemOrdered
    {
        public ProductItemOrdered()
        {
        }

        public ProductItemOrdered(int productItemId, string productName, string psictureUrl)
        {
            ProductItemId = productItemId;
            ProductName = productName;
            PsictureUrl = psictureUrl;
        }

        public int ProductItemId { get; set; }
        public string ProductName { get; set; }
        public string PsictureUrl { get; set; }
    }
}
