using System;

namespace ProjectSIP.Services.Jwt
{
    public interface IJwtFactory
    {
        string GenerateAccessToken(int userId);
    }
}
