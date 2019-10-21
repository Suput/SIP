using System.Collections.Generic;

namespace ProjectSIP.Services.Jwt
{
    public interface IJwtFactory
    {
        string GenerateAccessToken(int userId, List<string> roles);
    }
}
