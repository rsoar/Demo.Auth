using Stateless.Auth.API.Core.Domain;
using Stateless.Auth.API.Core.Exceptions;

namespace Stateless.Auth.API.Core.Interfaces
{
    public interface IUserRepository
    {
        User FindUserByUsernameOrThrow(string username, ValidationException? exception);
        int Create(User user);
    }
}
