using Microsoft.AspNetCore.Identity;
using ProjectSIP.Models.Documents;
using System.Collections.Generic;

namespace ProjectSIP.Models.Identity
{
    public class User : IdentityUser<int>
    {
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Middlename { get; set; }
        public string Position { get; set; } // Employee
        public int Age { get; set; }

        #region Events
        public List<EventDocument> EventMainAccounts { get; set; }
        public List<EventDocument> EventSupervisors { get; set; }
        public List<EventDocument> EventOrganizators { get; set; }

        #endregion
    }
}
