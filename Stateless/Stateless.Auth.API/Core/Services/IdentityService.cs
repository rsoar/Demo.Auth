using Stateless.Auth.API.Core.Domain;
using Stateless.Auth.API.Core.Exceptions;
using Stateless.Auth.API.Core.Interfaces;
using Stateless.Auth.API.Presentation.DTOs.Request;

namespace Stateless.Auth.API.Core.Services
{
    public class IdentityService : IIdentityService
    {
        private readonly ITokenService _tokenSvc;
        private readonly IUserRepository _userRepository;

        public IdentityService(ITokenService tokenService, IUserRepository userRepository)
        {
            _tokenSvc = tokenService;
            _userRepository = userRepository;

        }

        private bool ValidatePassword(string raw, string password)
        {
            return BCrypt.Net.BCrypt.Verify(raw, password);
        }

        public AccessTokenDto SignIn(SignInDto dto)
        {
            User user = _userRepository.FindUserByUsernameOrThrow(dto.Username, new ValidationException(StatusCodes.Status400BadRequest, "Invalid Credentials"));

            if (ValidatePassword(dto.Password, user.Password) is false)
                throw new ValidationException(StatusCodes.Status400BadRequest, "Invalid credentials");

            return new(_tokenSvc.CreateAccessToken(user));
        }

        public AccessTokenDto Register(SignUpDto dto)
        {
            throw new NotImplementedException();
        }
    }
}
