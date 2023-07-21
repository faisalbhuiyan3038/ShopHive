using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopHive.API.Data;
using ShopHive.API.Models.DTO;
using ShopHive.API.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;

namespace ShopHive.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly ShopHiveDbContext dbContext;

        public UserController(ShopHiveDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var Users = await dbContext.Users.ToListAsync();

            return Ok(Users);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetUser(int id) { 
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        
    }
}
