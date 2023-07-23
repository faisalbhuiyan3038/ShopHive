using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopHive.API.Data;
using ShopHive.API.Models;

namespace ShopHive.API.Controllers
{
    public class ProductController : BaseAPIController
    {
        private readonly ShopHiveDbContext dbContext;

        public ProductController(ShopHiveDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await dbContext.Products.ToListAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);

            return Ok(product);
        }
    }
}
