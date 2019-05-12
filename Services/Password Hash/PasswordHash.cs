using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace GWebAPI.Services
{
    public class PasswordHash
    {
        public PasswordHash (string password, string salt)
        {
            Password = password;
            Salt = salt;
        }

        public string Salt {get; private set;}
        public string Password {get; private set;}
    }
}