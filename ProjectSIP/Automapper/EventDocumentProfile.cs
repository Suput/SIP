using AutoMapper;
using ProjectSIP.Models.Documents;
using ProjectSIP.Models.Requests.Documents;
using ProjectSIP.Models.Responses.Documents;

namespace ProjectSIP.Automapper
{
    public class EventDocumentProfile : Profile
    {
        public EventDocumentProfile()
        {
            CreateMap<EventDocument, EventDocumentView>();
            CreateMap<CreateEventDocumentRequest, EventDocument>();

            CreateMap<UserEventDocument, UserEventDocumentView>();
            CreateMap<CreateUserEventDocument, UserEventDocument>();
        }
    }
}
