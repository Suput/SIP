using AutoMapper;
using ProjectSIP.Models.Document;
using ProjectSIP.Models.Requests.Document;
using ProjectSIP.Models.Responses.Document;

namespace ProjectSIP.Automapper
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            // document
            CreateMap<Document, DocumentView>();
            CreateMap<CreateDocumentRequest, Document>();
            CreateMap<EditDocumentRequest, Document>();

            // from
            CreateMap<From, FromView>();
            CreateMap<FromCreate, From>();
            CreateMap<FromEdit, From>();

            // to
            CreateMap<To, ToView>();
            CreateMap<ToCreate, To>();
            CreateMap<ToEdit, To>();
        }
    }
}
