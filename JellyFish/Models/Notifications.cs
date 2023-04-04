using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JellyFish.Models
{
    public class Notifications
    {
        
        public int Id { get; set; } 

        public string Text { get; set; }

        //public bool IsRead { get; set; } = false;

        //[ValidateNever]
        public virtual List<NotificationApplicationUser> NotificationApplicationUser { get; set; }
        //[ForeignKey("Id")]
        //public virtual ICollection<NotificationApplicationUser> NotificationApplicationUser { get; } = new List<NotificationApplicationUser>();
    }
}
