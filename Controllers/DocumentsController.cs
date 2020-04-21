using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SilencershopTest.DataAccess;
using SilencershopTest.Interfaces;
using SilencershopTest.Models;

namespace SilencershopTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocumentsController : ControllerBase
    {
        #region Local Variables
        private readonly AppDbContext _context;
        private readonly ILogger<DocumentsController> _logger;
        #endregion Local Variable

        #region Constructor Dependencies Injection
        /// <summary>
        /// Contructor Dependencies Injection
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public DocumentsController(AppDbContext context, ILogger<DocumentsController> logger)
        {
            _context = context;
            _logger = logger;
        }
        #endregion

        #region Endpoints
        [HttpGet("GetDocumentById/{documentId:int}")]
        public IActionResult GetDocumentById(int documentId)
        {
            try
            {
                Document document = _context.Documents.FirstOrDefault(document => document.Id == documentId);
                return Ok(File(document.File, document.ContentType, document.FileName));
            }
            catch(Exception ex)
            {
                _logger.LogInformation(121, "Something unexpected happens during the access documents", ex.InnerException.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("GetDocumentDetails/{documentId:int}")]
        public IActionResult GetDocumentDetails(int documentId)
        {
            if (documentId == 0)
            {
                return NotFound();
            } 
            else
            {
                try
                {
                    Document document = _context.Documents.FirstOrDefault(document => document.Id == documentId);
                    return new OkObjectResult(new { document });
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("Some Error occured which interecting with DB", ex.InnerException.Message);
                    throw;
                }
            }
        }

        [HttpPost]
        public async Task<OkResult> PostDocument([FromForm]IDocument document)
        {
            var ImageInBytes = new byte[document.File.Length];
            if (document.File.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await document.File.CopyToAsync(stream);
                    ImageInBytes = stream.ToArray();
                }
            }
            try
            {
                _context.Documents.Add(new Document { 
                    DocumentName= document.Name,
                    File = ImageInBytes,
                    ContentType = document.File.ContentType,
                    FileName = document.File.FileName,
                    ContentDisposition = document.File.ContentDisposition,
                    UserId = document.UploadedByUserId
                });
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("There is some error in fetching the Document:", ex.InnerException.Message);
                throw;
            }
            return Ok();
        }
        #endregion
    }
}