using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProjectSIP.Data;
using ProjectSIP.Exceptions;
using ProjectSIP.Models.Documents;
using ProjectSIP.Models.Identity;
using ProjectSIP.Models.Requests.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSIP.Controllers.Documents
{
    [Route("api/eventdocs")]
    public class EventDocumentController : MainController
    {
        private readonly IMapper mapper;
        private readonly ILogger<EventDocumentController> logger;
        private readonly DatabaseContext context;

        public EventDocumentController(UserManager<User> userManager, IMapper mapper,
            ILogger<EventDocumentController> logger, DatabaseContext context) : base(userManager)
        {
            this.mapper = mapper;
            this.logger = logger;
            this.context = context;
        }

        [HttpPost]
        public async Task<ActionResult> CreateEventDocument(CreateEventDocumentRequest request)
        {
            try
            {
                var eventDocument = mapper.Map<EventDocument>(request);
                eventDocument.MainAccountant = await userManager.FindByIdAsync(eventDocument.MainAccountantId.ToString())
                    ?? throw new CantFindUserException();

                eventDocument.Supervisor = await userManager.FindByIdAsync(eventDocument.SupervisorId.ToString())
                    ?? throw new CantFindUserException();

                eventDocument.Organizator = await userManager.FindByIdAsync(eventDocument.OrganizatorId.ToString())
                    ?? throw new CantFindUserException();

                eventDocument.UserEventDocuments = new List<UserEventDocument>();
                foreach(var createUser in request.CreateUserEventDocuments)
                {
                    var user = await userManager.FindByIdAsync(createUser.UserId.ToString())
                        ?? throw new CantFindUserException();

                    eventDocument.UserEventDocuments.Add(new UserEventDocument
                    {
                        UserId = createUser.UserId,
                        User = user,
                        EventDocumentId = eventDocument.Id,
                        EventDocument = eventDocument
                    });
                }

                context.EventDocuments.Add(eventDocument);
                await context.SaveChangesAsync();
                return Ok();
            }
            catch (CantFindUserException cfue)
            {
                logger.LogWarning(cfue.Message + "\n" + cfue.StackTrace);
                logger.LogWarning("--- INNER EXCEPTION: ---\n" + cfue.InnerException.Message);
                throw new CantFindUserException();
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message + "\n" + ex.StackTrace);
                logger.LogError("--- INNER EXCEPTION: ---\n" + ex.InnerException.Message);
                throw new CantSaveDatabaseException();
            }
        }
    }
}
