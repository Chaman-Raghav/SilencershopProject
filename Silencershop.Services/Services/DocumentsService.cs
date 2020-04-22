using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SilencershopTest.DataAccess;
using SilencershopTest.Interfaces;
using SilencershopTest.Models;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Silencershop.ServiceLayer.Services.IServices;

namespace Silencershop.ServiceLayer.Services
{
    public class DocumentsService : IDocumentsService
    {
        #region Local Variables
        private readonly AppDbContext _context;
        private readonly ILogger<DocumentsService> _logger;
        #endregion Local Variable

        #region Constructor Dependencies Injection
        /// <summary>
        /// Contructor Dependencies Injection
        /// </summary>
        /// <param name="context"></param>
        /// <param name="logger"></param>
        public DocumentsService(AppDbContext context, ILogger<DocumentsService> logger)
        {
            _context = context;
            _logger = logger;
        }
        #endregion

        public Document GetDocumentById(int documentId)
        {
            Document document = new Document();
            try
            {
                return _context.Documents.FirstOrDefault(document => document.Id == documentId);
            }
            catch (Exception ex)
            {
                _logger.LogInformation(121, "Something unexpected happens during the access documents", ex.InnerException.Message);
                return document;
            }
        }

        public Document GetDocumentDetails(int documentId)
        {
            Document document = new Document();
            if (documentId == 0)
            {
                return document;
            }
            else
            {
                try
                {
                    return _context.Documents.FirstOrDefault(document => document.Id == documentId);
                }
                catch (Exception ex)
                {
                    _logger.LogInformation("No Document Exist with Id: " + documentId + ex.Message);
                    return document;
                }
            }
        }

        public async Task<IActionResult> PostDocument(IDocument document)
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
                _context.Documents.Add(new Document
                {
                    DocumentName = document.Name,
                    File = ImageInBytes,
                    ContentType = document.File.ContentType,
                    FileName = document.File.FileName,
                    ContentDisposition = document.File.ContentDisposition,
                    UserId = document.UploadedByUserId
                });
                _context.SaveChanges();
                return new OkObjectResult("Document Successfully Saved");
            }
            catch (DbUpdateException ex)
            {
                return new OkObjectResult("Document Save Failed: " + ex.Message);
            }
        }
    }
}
