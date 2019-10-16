using System.ComponentModel.DataAnnotations;

namespace ProjectSIP.Models.Requests.Document
{
    public class ToCreate
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string Departure { get; set; }
    }
}
