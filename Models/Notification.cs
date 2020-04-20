using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SilencershopTest.Models
{
    public class Notification
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool IsDisplayed { get; set; }
        public DateTime CreationDate { get; set; }

        #region ForeignKey
        [ForeignKey("Id")]
        public int UserId { get; set; }
        public User User { get; set; }

        [ForeignKey("Id")]
        public int DocumentId { get; set; }
        public Document Document { get; set; }

        [ForeignKey("Id")]
        public int EventId { get; set; }
        public NotificationEventType NotificationEventType { get; set; }
        #endregion
    }
}
