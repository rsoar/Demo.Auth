using Stateless.Auth.API.Core.Domain;
using Stateless.Auth.API.Core.Interfaces;
using Stateless.Auth.API.Shared.Notification;

namespace Stateless.Auth.API.Core.Validators
{
    public class UserValidator : IValidator<User>
    {
        private bool IsUsernameValid(string username)
        {
            return string.IsNullOrWhiteSpace(username) is false;
        }

        private bool IsEmailValid(string email)
        {
            if(string.IsNullOrWhiteSpace(email))
                return false;

            return true;
        }

        private bool IsPasswordValid(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                return false;

            if (password.Length < 6)
                return false;

            return true;
        }

        public void Validate(User model, NotificationContext notificationContext)
        {
            bool usernameValid = IsUsernameValid(model.UserName);
            bool emailValid = IsEmailValid(model.Email);
            bool passwordValid = IsPasswordValid(model.Password);

            if (usernameValid is false)
                notificationContext.AddNotification("INVALID_USERNAME", "The provided username is invalid or empty.");

            if (emailValid is false)
                notificationContext.AddNotification("INVALID_EMAIL", "The provided e-mail is invalid or empty.");

            if (passwordValid is false)
                notificationContext.AddNotification("INVALID_PASSWORD", "The password must contain at least 6 characters.");

        }
    }
}
