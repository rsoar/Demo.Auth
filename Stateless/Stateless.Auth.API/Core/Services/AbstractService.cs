using Stateless.Auth.API.Shared.Notification;

namespace Stateless.Auth.API.Core.Services
{
    public abstract class AbstractService
    {
        protected NotificationContext NotificationContext { get; set; }

        public AbstractService(NotificationContext notificationContext)
        {
            NotificationContext = notificationContext;    
        }
    }
}
