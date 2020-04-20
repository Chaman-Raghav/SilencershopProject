using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SilencershopTest.Models
{
    public class UserLoginHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public DateTime LoginTime { get; set; }
        public DateTime LogoutTime { get; set; }

        #region ForeignKeys
        [ForeignKey("Id")]
        public int UserId { get; set; }
        public User User { get; set; }
        #endregion

    }
}
