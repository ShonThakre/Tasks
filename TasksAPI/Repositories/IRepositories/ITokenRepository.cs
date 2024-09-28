using Microsoft.AspNetCore.Identity;

namespace TasksAPI.Repositories.IRepositories
{
    public interface ITokenRepository
    {
        string CreateJWTToken(IdentityUser identityUser);
    }
}
