using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopHive.API.Data;
using ShopHive.API.Models;
using ShopHive.API.Models.DTO;
using System.Security.Cryptography;
using System.Text;

namespace ShopHive.API.Controllers
{
    public class AccountController:BaseAPIController
    {
        private readonly ShopHiveDbContext dbContext;

        public AccountController(ShopHiveDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.UserName.ToLower()))
            {
                return BadRequest("Username is taken.");
            }

            using var hmac = new HMACSHA512();

            var user = new User
            {
                UserName = registerDto.UserName.ToLower(),
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Mobile = registerDto.Mobile,
                Address =   registerDto.Address,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDto.Password)),
                PasswordSalt = hmac.Key
            };

            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }

        private async Task<bool> UserExists(string username)
        {
            return await dbContext.Users.AnyAsync(x => x.UserName == username.ToLower());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == id);

            dbContext.Remove(user);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await dbContext.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.UserName);

            if(user == null)
            {
                return Unauthorized("Invalid User");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for(int i=0; i<computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid Password");
                }
            }

            return Ok(user);
        }
    }
}
