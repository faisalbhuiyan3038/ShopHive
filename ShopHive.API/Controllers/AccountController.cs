using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShopHive.API.Data;
using ShopHive.API.Models;
using ShopHive.API.Models.DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ShopHive.API.Controllers
{
    public class AccountController : BaseAPIController
    {
        private readonly ShopHiveDbContext dbContext;
        private readonly IConfiguration _configuration;

        public AccountController(ShopHiveDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (await UserExists(registerDto.UserName.ToLower()))
            {
                return BadRequest("Username is taken.");
            }
            else if (await EmailExists(registerDto.Email.ToLowerInvariant()))
            {
                return BadRequest("Email is already in use.");
            }

            using var hmac = new HMACSHA512();

            var user = new User
            {
                UserName = registerDto.UserName.ToLower(),
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Mobile = registerDto.Mobile,
                Address = registerDto.Address,
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

        private async Task<bool> EmailExists(string email)
        {
            return await dbContext.Users.AnyAsync(x => x.Email == email.ToLower());
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

        //[HttpPost("login")]
        //public async Task<IActionResult> Login(LoginDto loginDto)
        //{
        //    var user = await dbContext.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.UserName);

        //    if(user == null)
        //    {
        //        return Unauthorized("Invalid User");
        //    }

        //    using var hmac = new HMACSHA512(user.PasswordSalt);

        //    var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

        //    for(int i=0; i<computedHash.Length; i++)
        //    {
        //        if (computedHash[i] != user.PasswordHash[i])
        //        {
        //            return Unauthorized("Invalid Password");
        //        }
        //    }

        //    return Ok(user);
        //}

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            var user = await dbContext.Users.SingleOrDefaultAsync(x => x.UserName == loginDto.UserName);

            if (user == null)
            {
                return Unauthorized("Invalid User");
            }

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDto.Password));

            for (int i = 0; i < computedHash.Length; i++)
            {
                if (computedHash[i] != user.PasswordHash[i])
                {
                    return Unauthorized("Invalid Password");
                }
            }

            // User is authenticated, generate a JWT token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("Jwt:Key").Value);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
        new Claim(ClaimTypes.Name, user.UserName),
        // Add more claims as needed
    }),
                Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            // Create the response object with email and userName
            var responseObj = new
            {
                email = user.Email,
                userName = user.UserName,
                token = tokenString
            };

            return Ok(responseObj);

        }
    }
}
