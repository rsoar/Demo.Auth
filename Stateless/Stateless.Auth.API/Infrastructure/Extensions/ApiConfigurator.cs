using Stateless.Auth.API.Core.Interfaces;
using Stateless.Auth.API.Core.Services;
using Stateless.Auth.API.Infrastructure.Data.Repositories;

namespace Stateless.Auth.API.Infrastructure.Extensions
{
    public static class ApiConfigurator
    {
        public static WebApplicationBuilder ConfigureRepositories(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped<IUserRepository, UserRepository>();

            return builder;
        }

        public static WebApplicationBuilder ConfigureServices(this WebApplicationBuilder builder)
        {
            builder.Services
                .AddScoped<ITokenService, JwtService>()
                .AddScoped<IIdentityService, IdentityService>();

            return builder;
        }
    }
}
