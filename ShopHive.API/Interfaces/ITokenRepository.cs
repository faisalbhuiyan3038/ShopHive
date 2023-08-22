using Microsoft.AspNetCore.Identity;

namespace ShopHive.API.Interfaces
{
    public interface ITokenRepository
    {
        string CreateJwtToken(IdentityUser user, List<string> roles);
    }
}
