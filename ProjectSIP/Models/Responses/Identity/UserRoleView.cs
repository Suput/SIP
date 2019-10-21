using System.Collections.Generic;

namespace ProjectSIP.Models.Responses.Identity
{
    public class UserRoleView
    {
        public UserView User { get; set; }
        public List<string> Roles { get; set; }
    }
}
