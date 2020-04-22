using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Silencershop.ServiceLayer.Services.IServices;
using SilencershopTest.Interfaces;
using SilencershopTest.Models;

namespace SilencershopTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        #region Local Variables
        IDocumentsService _documentsService;
        #endregion Local Variable

        #region Constructor Dependencies Injection
        /// <summary>
        /// Contructor Dependencies Injection
        /// </summary>
        /// <param name="documentsService"></param>
        public DocumentsController(IDocumentsService documentsService)
        {
            _documentsService = documentsService;
        }
        #endregion

        #region Endpoints
        [HttpGet("GetDocumentById/{documentId:int}")]
        public IActionResult GetDocumentById(int documentId)
        {
           var document = _documentsService.GetDocumentById(documentId);
            return File(document.File, document.ContentType, document.FileName);
        }

        [HttpGet]
        [Route("GetDocumentDetails/{documentId:int}")]
        public Document GetDocumentDetails(int documentId)
        {
            return _documentsService.GetDocumentDetails(documentId);
        }

        [HttpPost("SaveDocument")]
        public async Task<IActionResult> PostDocument([FromForm]IDocument document)
        {
            return await _documentsService.PostDocument(document);
        }
        #endregion Endpoints
    }
}