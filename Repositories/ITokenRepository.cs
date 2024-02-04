using Microsoft.AspNetCore.Identity;

namespace TasksAPI.Repositories
{
    public interface ITokenRepository
    {
       string CreateJWTToken(IdentityUser identityUser);
    }
}
