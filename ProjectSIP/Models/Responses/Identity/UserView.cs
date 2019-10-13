using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectSIP.Models.Responses.Identity
{
    public class UserView
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Middlename { get; set; }
        public string Position { get; set; } // Employee
        public int Age { get; set; }
    }
}
