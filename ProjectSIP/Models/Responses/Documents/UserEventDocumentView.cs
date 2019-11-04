using ProjectSIP.Models.Responses.Identity;

namespace ProjectSIP.Models.Responses.Documents
{
    public class UserEventDocumentView
    {
        public int UserId { get; set; }
        public UserView User { get; set; }
    }
}
