using System.Collections.Generic;
using System.Linq;
using SD.Transfer.Business.Interfaces;
using SD.Transfer.Business.Enums;

namespace SD.Transfer.Business.Notifications
{
    public class Notifier : INotifier
    {
        private readonly List<Notification> _notifications;

        public Notifier()
        {
            _notifications = new List<Notification>();
        }

        public void Handle(Notification notification)
        {
            _notifications.Add(notification);
        }

        public IEnumerable<Notification> GetNotifications()
        {
            return _notifications;
        }

        public bool HasErrors()
        {
            return _notifications.Where(p => p.Type == MessageType.Error).Any();
        }
    }
}