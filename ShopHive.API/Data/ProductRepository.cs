using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopHive.API.Interfaces;
using ShopHive.API.Models;

namespace ShopHive.API.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly ShopHiveDbContext dbContext;
        public ProductRepository(ShopHiveDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await dbContext.Products.FindAsync(id); 
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync()
        {
            return await dbContext.Products.ToListAsync();
        }
    }
}
