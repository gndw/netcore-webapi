using System;
using System.Security.Claims;

namespace GWebAPI.Services
{
    public interface IGwebTokenService
    {
        Token GenerateToken (Claim[] claims, DateTime expires);
        Token GenerateToken (Claim[] claims);
    }
}
