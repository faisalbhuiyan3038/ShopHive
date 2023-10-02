using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopHive.API.Data;
using ShopHive.API.Interfaces;
using ShopHive.API.Models.DTO;
using ShopHive.API.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using ShopHive.API.Errors;

namespace ShopHive.API.Controllers
{
    public class AdminController : BaseAPIController
    {
        private readonly ShopHiveDbContext dbContext;
        private readonly IConfiguration _configuration;
        private readonly ITokenRepository tokenRepository;

        public AdminController(ShopHiveDbContext dbContext, IConfiguration configuration, ITokenRepository tokenRepository)
        {
            this.dbContext = dbContext;
            _configuration = configuration;
            this.tokenRepository = tokenRepository;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterAdminDto registerAdminDto)
        {
         
            if (await EmailExists(registerAdminDto.Email.ToLowerInvariant()))
            {
                return BadRequest("Email is already in use.");
            }

            using var hmac = new HMACSHA512();

            var user = new AdminUser
            {
                email = registerAdminDto.Email,
                PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerAdminDto.Password)),
                PasswordSalt = hmac.Key
            };

            dbContext.AdminUsers.Add(user);
            await dbContext.SaveChangesAsync();

            return Ok(user);
        }

        private async Task<bool> EmailExists(string email)
        {
            return await dbContext.AdminUsers.AnyAsync(x => x.email == email.ToLower());
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var adminUser = await dbContext.AdminUsers.FirstOrDefaultAsync(x => x.Id == id);

            dbContext.Remove(adminUser);
            await dbContext.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(RegisterAdminDto registerAdminDto)
        {
            AdminUser user = await dbContext.AdminUsers.SingleOrDefaultAsync(x => x.email == registerAdminDto.Email);

            if (user == null)
            {
                var apiResponse = new ApiResponse(401, "Wrong credentials");
                return apiResponse.ToActionResult();
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerAdminDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    var apiResponse = new ApiResponse(401, "Wrong credentials");
                    return apiResponse.ToActionResult();
                }
            }

            var tokenString = tokenRepository.CreateJwtToken(user);

            // Create the response object with email and userName
            var responseObj = new
            {
                email = user.email,
                token = tokenString
            };

            return Ok(responseObj);

        }
    }
}
