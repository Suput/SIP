using ProjectSIP.Models.Responses.Identity;
using System;
using System.Collections.Generic;

namespace ProjectSIP.Models.Responses.Documents
{
    public class EventDocumentView
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string LawNumber { get; set; }

        public string Name { get; set; }
        public string Fullname { get; set; }
        public DateTime EventStart { get; set; }
        public string Targets { get; set; }
        public int SpendMoney { get; set; }

        public int MainAccountantId { get; set; }
        public UserView MainAccountant { get; set; }

        public List<UserEventDocumentView> UserEventDocuments { get; set; }

        public int SupervisorId { get; set; }
        public UserView Supervisor { get; set; }

        public string DivisionName { get; set; }
        public string NecessariesFromDivision { get; set; }

        public int OrganizatorId { get; set; }
        public UserView Organizator { get; set; }

        public string SupervisorSigniture { get; set; }
    }
}
