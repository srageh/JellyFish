using JellyFish.Models;

namespace JellyFish.Repository.IRepository
{
    public interface INotificationRepository
    {
        List<NotificationApplicationUser> GetUserNotifications(string userId);
        void Create(Notifications notification, string userId);
        void ReadNotification(int notificationId, string userId);
    }
}
