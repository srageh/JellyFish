using JellyFish.Models;
using JellyFish.Repository.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JellyFish.Repository
{
    public class NotificationRepository : INotificationRepository
    {
        private JellyFishDbContext _context;
        private IJobRepository _jobRepository;

        public NotificationRepository(JellyFishDbContext context, IJobRepository jobRepository)
        {
            _context = context;
            _jobRepository = jobRepository;
        }


        public List<NotificationApplicationUser> GetUserNotifications(string userId)
        {
            return _context.NotificationApplicationUser.Where(u => u.ApplicationUserId.Equals(userId) && !u.IsRead)
                                            .Include(n => n.Notifications)                                  
                                            .ToList();
        }

        public void Create(Notifications notification, string userId)
        {
            _context.Notifications.Add(notification);
            _context.SaveChanges();
            

            //TODO: Assign notification to users
            var watchlists = _jobRepository.GetWatchlistFromUserId(userId);
            //var watchlist = _context.Jobs.Where(x => x.EmployerId == userId).ToList();

            foreach (var watchlist in watchlists)
            {


                var userNotification = new NotificationApplicationUser();
                
                userNotification.ApplicationUserId = watchlist.EmployerId;
                userNotification.NotificationsId = notification.Id;
            
                

                _context.NotificationApplicationUser.Add(userNotification);
              
                _context.SaveChanges();

            }


            //_hubContext.Clients.All.InvokeAsync("displayNotification", "");
        }

        public void ReadNotification(int notificationId, string userId)
        {
            var notification = _context.NotificationApplicationUser
                                        .FirstOrDefault(n => n.ApplicationUserId.Equals(userId)
                                        && n.NotificationId == notificationId);
            notification.IsRead = true;
            _context.NotificationApplicationUser.Update(notification);
            _context.SaveChanges();
        }
    }
}
