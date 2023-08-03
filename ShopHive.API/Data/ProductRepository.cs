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
            return await dbContext.Products.Include(x => x.Category).FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IReadOnlyList<Product>> GetProductsAsync(string categoryName, string sortBy)
        {
            if(categoryName == "All")
            {
                switch(sortBy)
                {
                    case "name":
                        return await dbContext.Products.OrderBy(p=>p.Name).Include(x => x.Category).ToListAsync();
                    case "priceAsc":
                        return await dbContext.Products.OrderBy(p => p.Price).Include(x => x.Category).ToListAsync();
                    case "priceDesc":
                        return await dbContext.Products.OrderByDescending(p => p.Price).Include(x => x.Category).ToListAsync();
                    default:
                        return await dbContext.Products.Include(x => x.Category).ToListAsync();
                }   
                
            }
            else
            {
                switch (sortBy)
                {
                    case "name":
                        return await dbContext.Products.OrderBy(p => p.Name).Include(x => x.Category).Where(x => x.Category.Name == categoryName).ToListAsync();
                    case "priceAsc":
                        return await dbContext.Products.OrderBy(p => p.Price).Include(x => x.Category).Where(x => x.Category.Name == categoryName).ToListAsync();
                    case "priceDesc":
                        return await dbContext.Products.OrderByDescending(p => p.Price).Include(x => x.Category).Where(x => x.Category.Name == categoryName).ToListAsync();
                    default:
                        return await dbContext.Products.Include(x => x.Category).Where(x => x.Category.Name == categoryName).ToListAsync();
                }
                
            }
        }
    }
}
