using ShopHive.API.Models;
using System.Collections.Generic;

namespace ShopHive.API.Interfaces
{
    public interface IProductRepository
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IReadOnlyList<Product>> GetProductsAsync();
    }
}
