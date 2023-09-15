using Microsoft.AspNetCore.Identity;
using ShopHive.API.Interfaces;
using ShopHive.API.Models;
using StackExchange.Redis;
using System.Text.Json;

namespace ShopHive.API.Data
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDatabase _database;

        public BasketRepository(IConnectionMultiplexer redis)
        {
            _database = redis.GetDatabase();
        }

        async Task<bool> IBasketRepository.DeleteBasketAsync(string basketId)
        {
            return await _database.KeyDeleteAsync(basketId);
        }

        async Task<CustomerBasket> IBasketRepository.GetBasketAsync(string basketId)
        {
            var data = await _database.StringGetAsync(basketId);

            return data.IsNullOrEmpty ? null : JsonSerializer.Deserialize<CustomerBasket>(data);
        }

        async Task<CustomerBasket> IBasketRepository.UpdateBasketAsync(CustomerBasket basket)
        {
            var expirationTime = TimeSpan.FromDays(30);
            var created = await _database.StringSetAsync(basket.Id, JsonSerializer.Serialize(basket), expirationTime);

            if (!created) return null;

            return await ((IBasketRepository)this).GetBasketAsync(basket.Id);
        }
    }
}
