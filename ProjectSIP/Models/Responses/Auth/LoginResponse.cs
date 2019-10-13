using ProjectSIP.Models.Responses.Identity;

namespace ProjectSIP.Models.Responses.Auth
{
    public class LoginResponse
    {
        public UserView User { get; set; }
        public string AccessToken { get; set; }
    }
}
