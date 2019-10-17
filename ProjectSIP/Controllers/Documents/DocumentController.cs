using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ProjectSIP.Data;
using ProjectSIP.Exceptions;
using ProjectSIP.Models.Document;
using ProjectSIP.Models.Identity;
using ProjectSIP.Models.Requests.Document;
using ProjectSIP.Models.Responses.Document;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSIP.Controllers.Documents
{
    [Route("api/docs")]
    public class DocumentController : MainController
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;
        private readonly ILogger<DocumentController> logger;

        public DocumentController(UserManager<User> userManager, DatabaseContext context,
            IMapper mapper, ILogger<DocumentController> logger) : base(userManager)
        {
            this.context = context;
            this.mapper = mapper;
            this.logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<DocumentView>> CreateAsync(CreateDocumentRequest createDocumentRequest)
        {
            try
            {
                Document documentToCreate = mapper.Map<Document>(createDocumentRequest);
                context.Documents.Add(documentToCreate);
                await context.SaveChangesAsync();
                return Ok(
                    await (context
                        .Documents
                        .Where(doc => doc.Id == documentToCreate.Id))
                    .ProjectTo<DocumentView>(mapper.ConfigurationProvider)
                    .SingleAsync());
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message + "\n" + ex.StackTrace);
                logger.LogError("--- INNER EXCEPTION: ---\n" + ex.InnerException.Message);
                throw new CantSaveDatabaseException();
            }
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentView>>> GetAllDocs()
        => Ok(
                await (context
                    .Documents
                    .Include(doc => doc.From.User)
                    .Include(doc => doc.To.User))
                .ProjectTo<DocumentView>(mapper.ConfigurationProvider)
                .ToListAsync());

        [HttpGet("{docId:int}")]
        public async Task<ActionResult<DocumentView>> GetOneDoc(int docId)
            => Ok(
                await context
                    .Documents
                .ProjectTo<DocumentView>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(doc => doc.Id == docId));
    }
}
