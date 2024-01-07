namespace Stateless.Auth.API.Presentation.DTOs.Request
{
    public record SignUpDto(
        string Username,
        string Email,
        string Password
        );
}
