using Microsoft.AspNetCore.Mvc;
using Silencershop.ServiceLayer.Interfaces;
using Silencershop.DataObjects.Models;
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
