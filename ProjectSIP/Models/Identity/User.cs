using Microsoft.AspNetCore.Identity;
using ProjectSIP.Models.Document;
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

        public List<From> Froms { get; set; }
        public List<To> Tos { get; set; }
    }
}
