using JellyFish.Areas.Identity.Data;
using JellyFish.Models;
using JellyFish.Repository.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace JellyFish.Controllers
{
    [Authorize]
    public class NotificationController : Controller
    {
        private readonly INotificationRepository _notificationRepository;
        private readonly UserManager<JellyFishUser> _userManager;

        public NotificationController(INotificationRepository notificationRepository, UserManager<JellyFishUser> userManager)
        {
            _notificationRepository = notificationRepository;
            _userManager = userManager;
        }

        public IActionResult GetNotification()
        {
            var userId = _userManager.GetUserId(HttpContext.User);           
            var notification = _notificationRepository.GetUserNotifications(userId);
            return Ok(new { UserNotification = notification, Count = notification.Count });
        }

        public IActionResult ReadNotification(int notificationId)
        {
            _notificationRepository.ReadNotification(notificationId, _userManager.GetUserId(HttpContext.User));

            return Ok();
        }      
    }
}
