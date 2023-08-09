using Microsoft.AspNetCore.Identity;
using ShopHive.API.Models;
using ShopHive.API.Models.Identity;

namespace ShopHive.API.Data
{
    public class AppIdentityDbContextSeed
    {
        public static async Task SeedUsersAsync(UserManager<AppUser> userManager)
        {
            if (!userManager.Users.Any())
            {
                var user = new AppUser
                {
                    DisplayName = "Faisal",
                    Email = "faisal@gmail.com",
                    UserName = "faisal@gmail.com",
                    Address = new Address
                    {
                        Street = "Kuril",
                        City = "Dhaka",
                        State = "Dhaka",
                        Country = "Bangladesh",
                        PostalCode = "1229"
                    }
                };
                await userManager.CreateAsync(user, "Pa$$w0rd");
            }
        }
    }
}
