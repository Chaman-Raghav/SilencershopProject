using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SilencershopTest.Models
{
    public class Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string AuthorEmailAddress { get; set; }
        public string AuthorMobileNumber { get; set; }
        public int TotalDocumentFlagged { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        #region ForeignKeys
        [ForeignKey("Id")]
        public int AuditStatusId { get; set; }
        public AuditStatus AuditStatus { get; set; }

        [ForeignKey("Id")]
        public int FFLAdminId { get; set; }
        public User FFLAdmin { get; set; }

        [ForeignKey("Id")]
        public int IOIAdminId { get; set; }
        public User IOIAdmin { get; set; }

        #endregion
    }
}
