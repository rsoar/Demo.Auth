using Microsoft.IdentityModel.Tokens;
using Stateless.Auth.API.Core.Domain;
using Stateless.Auth.API.Core.Exceptions;
using Stateless.Auth.API.Core.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Stateless.Auth.API.Core.Services
{
    public class JwtService : ITokenService
    {
        private readonly int _ACCESS_TOKEN_EXPIRATION_HOURS = 1;
        private IConfiguration _configuration;
        private ILogger<JwtService> _logger;

        public JwtService(IConfiguration configuration, ILogger<JwtService> logger)
        {
            _configuration = configuration;
            _logger = logger;

        }

        public string CreateAccessToken(User user)
        {
            try
            {
                JwtSecurityTokenHandler jwtHandler = new();
                SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]));
                SigningCredentials creds = new(securityKey, SecurityAlgorithms.HmacSha256);

                Claim[] claims = new[]
                {
                    new Claim("idt", user.ExtId.ToString()),
                    new Claim("username", user.Username)
                };

                JwtSecurityToken token = new(
                    _configuration["Jwt:Issuer"],
                    _configuration["Jwt:Audience"],
                    claims,
                    expires: DateTime.Now.AddHours(_ACCESS_TOKEN_EXPIRATION_HOURS),
                    signingCredentials: creds
                    );

                return jwtHandler.WriteToken(token);
            }
            catch (Exception exc)
            {
                _logger.LogError($"An error ocurred in the {nameof(CreateAccessToken)} method. Exception: {exc.StackTrace}");
                throw;
            }
        }

        public bool ValidateAccessToken(string t)
        {
            if (string.IsNullOrWhiteSpace(t))
                throw new ValidationException(StatusCodes.Status401Unauthorized, "The access token was not informed.");

            JwtSecurityTokenHandler jwtHandler = new();
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);

            try
            {
                jwtHandler.ValidateToken(t, new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);


                return true;
            }
            catch
            {
                throw new ValidationException(StatusCodes.Status401Unauthorized, "The provided access token is invalid.");
            }
        }
    }
}
