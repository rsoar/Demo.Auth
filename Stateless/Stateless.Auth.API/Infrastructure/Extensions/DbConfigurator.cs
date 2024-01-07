using Microsoft.EntityFrameworkCore;
using Stateless.Auth.API.Infrastructure.Data.Context;

namespace Stateless.Auth.API.Infrastructure.Extensions
{
    public static class DbConfigurator
    {
        public static WebApplicationBuilder ConfigureDb(this WebApplicationBuilder builder)
        {
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration["SqlServer:ConnectionString"]));

            return builder;
        }
    }
}
