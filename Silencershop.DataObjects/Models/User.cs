using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Silencershop.DataObjects.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string FFLName { get; set; }
        public string MobileNumber { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string FirstThreeDigitOfFFL { get; set; }
        public string LastFiveDigitOfFFL { get; set; }
        public bool? DeleteDocumentsOnExpiration { get; set; }
        public byte[] Image { get; set; }
        public DateTime? CreationDate { get; set; }

        #region ForeignKeys
        [ForeignKey("Id")]
        public int? UserStatusId { get; set; }
        public UserStatus UserStatus { get; set; }

        [ForeignKey("Id")]
        public int? UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
        #endregion ForeignKeys

        public List<Document> Documents { get; set; }
        public List<UserLoginHistory> LoginHistory { get; set; }
        public List<Notification> Notifications { get; set; }

    }
}
