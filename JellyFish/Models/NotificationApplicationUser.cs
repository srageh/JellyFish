using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JellyFish.Models
{
    public class NotificationApplicationUser
    {
        [Key]
        public int NotificationId { get; set; }

        public string ApplicationUserId { get; set; } = string.Empty;

        public bool IsRead { get; set; } = false;

        public int NotificationsId { get; set; }

        //[ValidateNever]
        //public Notifications Notifications { get; set; }
        [ValidateNever]
        public virtual Notifications Notifications { get; set; } = null!;

        

        //public ApplicationUser ApplicationUser { get; set; }


    }
}
