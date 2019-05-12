using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using GWebAPI.Helpers;
using GWebAPI.Models;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GWebAPI.Services
{
    public class GwebPasswordHashService : IGWebPasswordHashService
    {
        public PasswordHash Generate(string raw)
        {
            string salt = GetSalt();
            return new PasswordHash ( Hash(raw, salt), salt);
        }

        public string Hash(string raw, string salt)
        {
            // derive a 256-bit subkey (use HMACSHA1 with 10,000 iterations)
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: raw,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            
            return hashed;
        }

        private string GetSalt ()
        {
            // generate a 128-bit salt using a secure PRNG
            byte[] salt = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return Convert.ToBase64String(salt);
        }
    }
}