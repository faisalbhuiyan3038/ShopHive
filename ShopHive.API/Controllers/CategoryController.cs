using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopHive.API.Data;
using ShopHive.API.Models;
using ShopHive.API.Models.DTO;

namespace ShopHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ShopHiveDbContext dbContext;

        public CategoryController(ShopHiveDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            // Get Data From Database - Domain Models
            var Categories = dbContext.Categories.ToList();

            // Map Domain Models to DTOs
            var categoryDto = new List<CategoryDto>();
            foreach(var category in Categories)
            {
                categoryDto.Add(new CategoryDto()
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                });
            }

            return Ok(categoryDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById([FromRoute] int id) 
        {
            //Find() can only be used with the primary key

            //Get Category Model from Db
            var categoryDomain = dbContext.Categories.Find(id);

            if(categoryDomain == null)
            {
                return NotFound();
            }

            //Map/Convert Category Domain Model to Category DTO
            var CategoryDto = new CategoryDto{
                Id = categoryDomain.Id,
                Name = categoryDomain.Name,
                Description = categoryDomain.Description,
            };


            return Ok(CategoryDto);
        }
    }
}
