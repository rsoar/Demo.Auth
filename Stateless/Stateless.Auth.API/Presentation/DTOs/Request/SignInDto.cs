namespace Stateless.Auth.API.Presentation.DTOs.Request
{
    public record SignInDto(
        string Username,
        string Password
        );
}
