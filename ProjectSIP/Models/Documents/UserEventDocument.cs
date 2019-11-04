using ProjectSIP.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSIP.Models.Documents
{
    public class UserEventDocument
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int EventDocumentId { get; set; }
        public EventDocument EventDocument { get; set; }
    }
}
