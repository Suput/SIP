using Microsoft.AspNetCore.Identity;

namespace ProjectSIP.Models.Identity
{
    public class User : IdentityUser<int>
    {
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Middlename { get; set; }
        public string Position { get; set; } // Employee
        public int Age { get; set; }
    }
}
