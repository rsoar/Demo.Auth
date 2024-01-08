using Stateless.Auth.API.Core.Entities;
using Stateless.Auth.API.Core.Validators;
using System.ComponentModel.DataAnnotations;

namespace Stateless.Auth.API.Core.Domain
{
    public class User : Entity
    {
        protected User() { }
        public User(string username, string email, string password)
        {
            ExtId = Guid.NewGuid();
            Username = username;
            Email = email;
            Password = password;

            Validate(this, new UserValidator());
        }

        public Guid ExtId { get; internal set; }
        [Required]
        public string Username { get; internal set;}
        [Required]
        public string Email { get; internal set;}
        [Required]
        public string Password { get; set; }
    }
}
