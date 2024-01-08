using Stateless.Auth.API.Core.Domain;
using Stateless.Auth.API.Core.Exceptions;

namespace Stateless.Auth.API.Core.Interfaces
{
    public interface IUserRepository
    {
        User FindUserByUsernameOrThrow(string username, ValidationException? exception);
        User? FindUserByUsername(string username);
        User? FindUserByEmail(string username);
        int Create(User user);
    }
}
