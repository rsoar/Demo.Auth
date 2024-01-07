using Microsoft.AspNetCore.Mvc;
using Stateless.Auth.API.Core.Interfaces;
using Stateless.Auth.API.Presentation.DTOs.Request;

namespace Stateless.Auth.API.Presentation.Controllers
{
    [ApiController]
    [Route("_api/identity")]
    public class IdentityController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult Register([FromServices] IIdentityService svc, [FromBody] SignUpDto dto)
        {
            return Ok(svc.Register(dto));
        }

        [HttpPost("login")]
        public IActionResult SignIn([FromServices] IIdentityService svc, [FromBody] SignInDto dto)
        {
            return Ok(svc.SignIn(dto));
        }

        [HttpPost("validate")]
        public IActionResult Validate([FromServices] ITokenService svc, [FromBody] AccessTokenDto dto)
        {
            return Ok(svc.ValidateAccessToken(dto.Access_token));
        }
    }
}
