using Silencershop.DataObjects.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Silencershop.DataObjects.Models
{
    public class FlaggedDocument
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string CurrentStatus { get; set; }
        public DateTime? FlaggedTime { get; set; }

        #region ForeignKeys
        [ForeignKey("Id")]
        public Document Document { get; set; }

        [ForeignKey("Id")]
        public User User { get; set; }
        #endregion ForeignKeys
    }
}
