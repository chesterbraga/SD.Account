using System.Collections.Generic;
using SD.Transfer.Business.Notifications;

namespace SD.Transfer.Business.Interfaces
{
    public interface INotifier
    {
        bool HasErrors();
        IEnumerable<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}