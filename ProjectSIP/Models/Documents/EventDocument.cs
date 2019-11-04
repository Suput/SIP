using ProjectSIP.Models.Identity;
using System;
using System.Collections.Generic;

namespace ProjectSIP.Models.Documents
{
    public class EventDocument
    {
        public int Id { get; set; }
        public string OrganizationName { get; set; }
        public string LawNumber { get; set; }

        #region Event outcome
        public string Name { get; set; }
        public string Fullname { get; set; }
        public DateTime EventStart { get; set; }
        public string Targets { get; set; }
        public int SpendMoney { get; set; }

        public int MainAccountantId { get; set; }
        public User MainAccountant { get; set; }
        
        public List<UserEventDocument> UserEventDocuments { get; set; }

        public int SupervisorId { get; set; }
        public User Supervisor { get; set; }

        public string DivisionName { get; set; }
        public string NecessariesFromDivision { get; set; }

        public int OrganizatorId { get; set; }
        public User Organizator { get; set; }

        public string SupervisorSigniture { get; set; }
        #endregion
    }
}
