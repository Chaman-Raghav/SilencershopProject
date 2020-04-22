using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Silencershop.DataObjects.Models
{
    public class Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string AuditorName { get; set; }
        public string AuditorEmailAddress { get; set; }
        public string AuditorMobileNumber { get; set; }
        public int TotalDocumentFlagged { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }

        #region ForeignKeys
        [ForeignKey("AuditStatusId")]
        public AuditStatus AuditStatus { get; set; }

        [ForeignKey("FFLAdminId")]
        public User FFLAdmin { get; set; }

        [ForeignKey("IOIAdminId")]
        public User IOIAdmin { get; set; }
        #endregion

        List<Auditor> Auditors { get; set; }
    }
}
