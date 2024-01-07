using Stateless.Auth.API.Core.Domain;
using Stateless.Auth.API.Core.Exceptions;
using Stateless.Auth.API.Core.Interfaces;
using Stateless.Auth.API.Infrastructure.Data.Context;

namespace Stateless.Auth.API.Infrastructure.Data.Repositories
{
    public class UserRepository : AbstractRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context) { }

        public int Create(User user)
        {
            dbContext.Users.Add(user);
            return dbContext.SaveChanges();
        }

        public User FindUserByUsernameOrThrow(string username, ValidationException exception)
        {
            return dbContext.Users.FirstOrDefault(u => u.UserName == username) 
                ?? throw exception;
        }
    }
}
