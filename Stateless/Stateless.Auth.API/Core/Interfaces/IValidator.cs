using Stateless.Auth.API.Shared.Notification;

namespace Stateless.Auth.API.Core.Interfaces
{
    public interface IValidator<TModel>
    {
        void Validate(TModel model, NotificationContext notificationContext);
    }
}
