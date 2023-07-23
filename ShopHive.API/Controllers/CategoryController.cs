using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopHive.API.Data;
using ShopHive.API.Models;
using ShopHive.API.Models.DTO;

namespace ShopHive.API.Controllers
{
    public class CategoryController : BaseAPIController
    {
        private readonly ShopHiveDbContext dbContext;

        public CategoryController(ShopHiveDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            // Get Data From Database - Domain Models
            var Categories = await dbContext.Categories.ToListAsync();

            // Map Domain Models to DTOs
            var categoryDto = new List<CategoryDto>();
            foreach(var category in Categories)
            {
                if(category.IsDeleted==false)
                {
                    categoryDto.Add(new CategoryDto()
                    {
                        Id = category.Id,
                        Name = category.Name,
                        Description = category.Description,
                    });
                }
                
            }

            return Ok(categoryDto);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById([FromRoute] int id) 
        {
            //Find() can only be used with the primary key

            //Get Category Model from Db
            var categoryDomain = await dbContext.Categories.FindAsync(id);

            if(categoryDomain == null || categoryDomain.IsDeleted == true)
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


        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddCategoryRequestDto addCategoryRequestDto)
        {
            //Map or Convert DTO to Domain Model
            var categoryDomainModel = new Category
            {
                Name = addCategoryRequestDto.Name,
                Description = addCategoryRequestDto.Description,
            };

            //Use Domain Model to Create Category
            await dbContext.Categories.AddAsync(categoryDomainModel);
            await dbContext.SaveChangesAsync();

            //Map Domain Model Back to DTO
            var categoryDto = new CategoryDto
            {
                Id = categoryDomainModel.Id,
                Name = categoryDomainModel.Name,
                Description = categoryDomainModel.Description,
            };

            return CreatedAtAction(nameof(GetById), new { id = categoryDomainModel.Id }, categoryDomainModel);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCategoryRequestDto updateCategoryRequestDto)
        {
            //Check if Category Exists
            var categoryDomainModel = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if(categoryDomainModel == null || categoryDomainModel.IsDeleted == true)
            {
                return NotFound();
            }

            //Map Dto to Domain Model
            categoryDomainModel.Name = updateCategoryRequestDto.Name;
            categoryDomainModel.Description = updateCategoryRequestDto.Description;

            await dbContext.SaveChangesAsync();

            //Convert Domain Model to Dto
            var categoryDto = new CategoryDto
            {
                Id = categoryDomainModel.Id,
                Name = categoryDomainModel.Name,
                Description = categoryDomainModel.Description,
            };

            return Ok(categoryDto);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            //Check if Category Exists
            var categoryDomainModel = await dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);

            if (categoryDomainModel == null)
            {
                return NotFound();
            }

            categoryDomainModel.IsDeleted = true;
            await dbContext.SaveChangesAsync();

            return Ok(categoryDomainModel);
            
        }
    }
}
