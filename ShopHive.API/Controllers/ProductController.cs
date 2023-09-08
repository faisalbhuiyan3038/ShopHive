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
            var categoryInfo = await dbContext.Categories.FirstOrDefaultAsync(x => x.Name == catName);

            if (categoryInfo == null)
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

        //THis is only for adding seed data if DB ever gets deleted.
        //[HttpPost]
        //public async Task<IActionResult> AddSEEDData()
        //{
        //    //Get Category Id from name


        //    List<Product> SeedProducts = new List<Product>
        //    {
        //        new Product
        //        {
        //            Name = "Stylish Leather Wallet",
        //            Description = "A premium leather wallet with multiple card slots and a coin pocket.",
        //            Price = 29.99m,
        //            ProductImageUrl = "https://w7.pngwing.com/pngs/999/354/png-transparent-wallet-open-wallet-brown-leather-clothing-accessories-thumbnail.png",
        //            CategoryId = 1,
        //        },
        //        new Product
        //        {
        //            Name = "Classic Aviator Sunglasses",
        //            Description = "Timeless aviator sunglasses with UV protection and metal frame.",
        //            Price = 49.99m,
        //            ProductImageUrl = "https://images-cdn.ubuy.co.in/634e4f17527236373d59c95c-kids-polarized-aviator-sunglasses-for.jpg",
        //            CategoryId = 1,
        //        },
        //        new Product
        //        {
        //            Name = "Flagship Smartphone X",
        //            Description = "Powerful flagship smartphone with high-end features and a stunning display.",
        //            Price = 899.99m,
        //            ProductImageUrl = "https://m.media-amazon.com/images/I/61eyXBlFk7L.__AC_SX300_SY300_QL70_FMwebp_.jpg",
        //            CategoryId = 2,
        //        },
        //        new Product
        //        {
        //            Name = "Budget-Friendly Smartphone Y",
        //            Description = "Affordable smartphone with decent performance and a large battery.",
        //            Price = 249.99m,
        //            ProductImageUrl = "https://m.media-amazon.com/images/I/71zGrrAe5NL.__AC_SX300_SY300_QL70_FMwebp_.jpg",
        //            CategoryId = 2,
        //        },
        //        new Product
        //        {
        //            Name = "Deluxe Chocolate Assortment",
        //            Description = "An assortment of premium chocolates in a beautiful gift box.",
        //            Price = 19.99m,
        //            ProductImageUrl = "https://m.media-amazon.com/images/I/41LZiollO1S._SY300_SX300_QL70_FMwebp_.jpg",
        //            CategoryId = 3,
        //        },
        //        new Product
        //        {
        //            Name = "Gourmet Coffee Blend",
        //            Description = "Rich and aromatic coffee blend sourced from exotic locations.",
        //            Price = 12.99m,
        //            ProductImageUrl = "https://m.media-amazon.com/images/I/41grMvjBRHL._SX300_SY300_QL70_FMwebp_.jpg",
        //            CategoryId = 3,
        //        },
        //        new Product
        //        {
        //            Name = "Wireless Bluetooth Earbuds",
        //            Description = "Sleek and comfortable earbuds with noise-cancellation technology.",
        //            Price = 79.99m,
        //            ProductImageUrl = "https://m.media-amazon.com/images/I/714H35vQYRL.__AC_SX300_SY300_QL70_FMwebp_.jpg",
        //            CategoryId = 4,
        //        },
        //        new Product
        //        {
        //            Name = "Portable Power Bank",
        //            Description = "High-capacity power bank for charging devices on the go.",
        //            Price = 34.99m,
        //            ProductImageUrl = "https://m.media-amazon.com/images/I/51s1M4WRbFL.__AC_SX300_SY300_QL70_FMwebp_.jpg",
        //            CategoryId = 4,
        //        },
        //        new Product
        //        {
        //            Name = "Luxurious Facial Cream",
        //            Description = "A premium facial cream with anti-aging properties and natural ingredients.",
        //            Price = 59.99m,
        //            ProductImageUrl = "https://m.media-amazon.com/images/I/41ksofNVdjL._SX300_SY300_QL70_FMwebp_.jpg",
        //            CategoryId = 6,
        //        },
        //        new Product
        //        {
        //            Name = "Refreshing Body Wash",
        //            Description = "Revitalizing body wash with a delightful fragrance.",
        //            Price = 14.99m,
        //            ProductImageUrl = "https://m.media-amazon.com/images/I/31SoFbiaWxL._SX300_SY300_QL70_FMwebp_.jpg",
        //            CategoryId = 6,
        //        }
        //    };

        //    foreach (var seedProduct in SeedProducts)
        //    {
        //        var categoryInfo = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == seedProduct.CategoryId);
        //        seedProduct.Category = categoryInfo;
        //        await dbContext.Products.AddAsync(seedProduct);
        //    }

        //    //Use Domain Model to Create Product

        //    await dbContext.SaveChangesAsync();

        //    return Ok();
        //}
    }
}
