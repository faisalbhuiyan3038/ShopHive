using ShopHive.API.Models.OrderAggregate;
using System.Reflection;
using System.Text.Json;

namespace ShopHive.API.Data
{
    public class ShopHiveDbContextSeed
    {
        public static async Task SeedAsync(ShopHiveDbContext context)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            if (!context.DeliveryMethods.Any())
            {
                var deliveryData = File.ReadAllText(path + @"/Data/SeedData/delivery.json");
                var methods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryData);
                context.DeliveryMethods.AddRange(methods);
            }
        }
    }
}
