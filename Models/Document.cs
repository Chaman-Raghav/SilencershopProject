using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using SilencershopTest.Models;

namespace SilencershopTest.Models
{
    public class Document
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string DocumentName { get; set; }
        public byte[] File { get; set; }
        public string ContentType { get; set; }
        public string FileName { get; set; }
        public string ContentDisposition { get; set; }
        [ForeignKey("Id")]
        public int UserId { get; set; }
        public User UploadedBy { get; set; }
    }
}
