using ProjectSIP.Models.Identity;
using System.Collections.Generic;

namespace ProjectSIP.Models.Document
{
    public class From
    {
        public int Id { get; set; }
        public string Departure { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<Document> Documents { get; set; }
    }
}
