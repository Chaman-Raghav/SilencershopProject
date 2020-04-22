using Silencershop.DataObjects.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Silencershop.DataObjects.Models
{
    public class GlobalCorrectionLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string Description { get; set; }
        public DateTime? InitialDate { get; set; }

        #region ForeignKeys
        [ForeignKey("Id")]
        public Document Document { get; set; }
        #endregion ForeignKeys
    }
}
