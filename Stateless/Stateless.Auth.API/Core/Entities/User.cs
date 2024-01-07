using Stateless.Auth.API.Core.Entities;

namespace Stateless.Auth.API.Core.Domain
{
    public class User : Entity
    {
        protected User() { }
        public User(string username, string email, string password)
        {
            ExtId = Guid.NewGuid();
            UserName = username;
            Email = email;
            Password = password;
        }

        public Guid ExtId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
