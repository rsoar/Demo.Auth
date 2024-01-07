using Stateless.Auth.API.Presentation.DTOs.Request;

namespace Stateless.Auth.API.Core.Interfaces
{
    public interface IIdentityService
    {
        AccessTokenDto? Register(SignUpDto dto);
        AccessTokenDto SignIn(SignInDto dto);
    }
}
