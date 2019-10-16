using System.ComponentModel.DataAnnotations;

namespace ProjectSIP.Models.Requests.Document
{
    public class FromEdit
    {
        [Required]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Departure { get; set; }
    }
}
