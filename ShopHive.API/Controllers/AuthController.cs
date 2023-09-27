using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShopHive.API.Interfaces;
using ShopHive.API.Models.DTO;

namespace ShopHive.API.Controllers
{
    public class AuthController:BaseAPIController
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }

        //POST: /api/Auth/Register
        [HttpPost]
        [Route("IdentityRegister")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var identityUser = new IdentityUser
            {
                UserName = registerRequestDto.Username,
                Email = registerRequestDto.Username,

            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);

            if(identityResult.Succeeded)
            {
                //Add roles to this user
                if(registerRequestDto.Roles != null && registerRequestDto.Roles.Any()) 
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestDto.Roles);
                    if (identityResult.Succeeded)
                    {
                        return Ok("User was registered! Please login!");
                    }
                }
                
            }

            return BadRequest("Something went wrong!");
        }

        //POST: /api/Auth/Login
        //[HttpPost]
        //[Route("IdentityLogin")]
        //public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        //{
        //    var user = await userManager.FindByEmailAsync(loginRequestDto.Username);

        //    if(user != null)
        //    {
        //        var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);

        //        if (checkPasswordResult)
        //        {
        //            //Get Roles for this user
        //            var roles = await userManager.GetRolesAsync(user);

        //            if(roles != null)
        //            {
        //                //Create Token
        //                var jwtToken = tokenRepository.CreateJwtToken(user);
        //                var response = new LoginResponseDto
        //                {
        //                    JwtToken = jwtToken,
        //                };
        //                return Ok(response);
        //            }
        //        }
        //    }

        //    return BadRequest("Username or password incorrect");
        //}
    }
}
