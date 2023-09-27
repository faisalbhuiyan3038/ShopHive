using Microsoft.AspNetCore.Identity;
using ShopHive.API.Models;

namespace ShopHive.API.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJwtToken(User user);
    }
}
