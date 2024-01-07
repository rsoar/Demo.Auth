using Stateless.Auth.API.Infrastructure.Data.Context;

namespace Stateless.Auth.API.Infrastructure.Data.Repositories
{
    public abstract class AbstractRepository
    {
        protected AppDbContext dbContext;
        public AbstractRepository(AppDbContext context)
        {
            dbContext = context;
        }
    }
}
