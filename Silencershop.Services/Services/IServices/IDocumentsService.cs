using Microsoft.AspNetCore.Mvc;
using SilencershopTest.Interfaces;
using SilencershopTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Silencershop.ServiceLayer.Services.IServices
{
    public interface IDocumentsService
    {
        public Document GetDocumentById(int documentId);
        public Document GetDocumentDetails(int documentId);
        public Task<IActionResult> PostDocument(IDocument document);
    }
}
