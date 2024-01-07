namespace Stateless.Auth.API.Shared.Notification
{
    public class NotificationContext
    {
        private readonly List<Notification> _notifications = new();
        public IReadOnlyCollection<Notification> Notifications => _notifications;
        public bool HasNotification => _notifications.Any();

        public void AddNotification(string key, string message)
        {
            _notifications.Add(new Notification(key, message));
        }

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }

        public void AddNotification(List<Notification> notification)
        {
            _notifications.AddRange(notification);
        }

        public void AddNotifications(NotificationContext context)
        {
            _notifications.AddRange(context.Notifications);
        }
    }
}
