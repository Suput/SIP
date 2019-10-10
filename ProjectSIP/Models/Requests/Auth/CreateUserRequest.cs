using System.ComponentModel.DataAnnotations;

namespace ProjectSIP.Models.Requests.Auth
{
    public class CreateUserRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Secondname { get; set; }
        [Required]
        public string Middlename { get; set; }
        [Required]
        public string Position { get; set; } // Employee
        [Required]
        public int Age { get; set; }
    }
}
