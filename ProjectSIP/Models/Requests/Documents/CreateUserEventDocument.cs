using System.ComponentModel.DataAnnotations;

namespace ProjectSIP.Models.Requests.Documents
{
    public class CreateUserEventDocument
    {
        [Required]
        public int UserId { get; set; }
    }
}
