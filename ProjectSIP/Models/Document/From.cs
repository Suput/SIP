using ProjectSIP.Models.Identity;

namespace ProjectSIP.Models.Document
{
    public class From
    {
        public int Id { get; set; }
        public string Departure { get; set; }
        public User User { get; set; }
    }
}
