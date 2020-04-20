using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SilencershopTest.Interfaces
{
    public class IDocument
    {
        public string Name { get; set; }
        public IFormFile File { get; set; }
        public int UploadedByUserId { get; set; }
    }
}
