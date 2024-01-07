using Stateless.Auth.API.Core.Domain;

namespace Stateless.Auth.API.Core.Interfaces
{
    public interface ITokenService
    {
        string CreateAccessToken(User user);
        bool ValidateAccessToken(string accesstoken);
    }
}
