using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjectSIP.Models.Requests.Documents
{
    public class CreateEventDocumentRequest
    {
        [Required]
        public string OrganizationName { get; set; }
        [Required]
        public string LawNumber { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Fullname { get; set; }
        [Required]
        public DateTime EventStart { get; set; }
        [Required]
        public string Targets { get; set; }
        [Required]
        public int SpendMoney { get; set; }

        [Required]
        public int MainAccountantId { get; set; }

        [Required]
        public int SupervisorId { get; set; }

        [Required]
        public string DivisionName { get; set; }
        [Required]
        public string NecessariesFromDivision { get; set; }

        [Required]
        public int OrganizatorId { get; set; }

        public string SupervisorSigniture { get; set; }

        [Required]
        public List<CreateUserEventDocument> CreateUserEventDocuments { get; set; }
    }
}
