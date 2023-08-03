using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopHive.API.Data;
using ShopHive.API.Interfaces;
using ShopHive.API.Models;
using ShopHive.API.Models.DTO;

namespace ShopHive.API.Controllers
{
    public class ProductController : BaseAPIController
    {
        private readonly IProductRepository repo;
        private readonly ShopHiveDbContext dbContext;

        public ProductController(IProductRepository repo, ShopHiveDbContext dbContext)
        {
            this.repo = repo;
            this.dbContext = dbContext;
        }



        [HttpGet]
        public async Task<IActionResult> GetProducts(string categoryName, string sortBy)
        {
            var products = await repo.GetProductsAsync(categoryName,sortBy);
            return Ok(products);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await repo.GetProductByIdAsync(id);

            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> InsertProduct([FromBody] AddProductRequestDto addProductRequestDto)
        {
            //Get Category Id from name
            string catName = addProductRequestDto.CategoryName;
            var categoryInfo = await dbContext.Categories.FirstOrDefaultAsync(x=>x.Name==catName);

            if(categoryInfo == null)
            {
                return BadRequest("Category Not Found");
            }

            //Map or Convert DTO to Domain Model
            var ProductDomainModel = new Product
            {
                Name = addProductRequestDto.Name,
                Description = addProductRequestDto.Description,
                Price = addProductRequestDto.Price,
                ProductImageUrl = addProductRequestDto.ProductImageUrl,
                CategoryId = categoryInfo.Id,
                Category = categoryInfo
            };

            //Use Domain Model to Create Product
            await dbContext.Products.AddAsync(ProductDomainModel);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProduct), new { id = ProductDomainModel.Id }, ProductDomainModel);
        }
    }
}
