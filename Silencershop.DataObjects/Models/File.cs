using Silencershop.DataObjects.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Silencershop.DataObjects.Models
{
    public class File
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FileName { get; set; }
        public DateTime? UploadedDate { get; set; }

        #region ForeignKeys
        [ForeignKey("Id")]
        public User User { get; set; }

        [ForeignKey("Id")]
        public Document Document { get; set; }

        [ForeignKey("Id")]
        public FileType FileType { get; set; }
        #endregion ForeignKeys
    }
}
