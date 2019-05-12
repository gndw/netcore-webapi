using System;
using System.Security.Claims;

namespace GWebAPI.Services
{
    public interface IGWebPasswordHashService
    {
        PasswordHash Generate (string raw);
        string Hash (string raw, string salt);
    }
}
