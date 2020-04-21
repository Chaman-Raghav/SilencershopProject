using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SilencershopTest.Models
{
    public class Auditor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        #region ForeignKeys
        [ForeignKey("AuditId")]
        public int? AuditId { get; set; }
        public Audit Audit { get; set; }

        [ForeignKey("IOIUserId")]
        public int? IOIUserId { get; set; }
        public User IOIUser { get; set; }
        #endregion
    }
}
