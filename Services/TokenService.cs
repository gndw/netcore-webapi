using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GWebAPI.Helpers;
using GWebAPI.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace GWebAPI.Services
{
    public interface IGwebTokenService
    {
        Token GenerateToken (string claimName, DateTime expires);
        Token GenerateToken (string claimName);
    }

    public class GwebTokenService : IGwebTokenService
    {
        private readonly AppSettings _appSettings;

        public GwebTokenService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public Token GenerateToken (string claimName, DateTime expires)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                {
                    new Claim(ClaimTypes.Name, claimName)
                }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Token(token);
        }

        public Token GenerateToken (string claimName)
        {
            return GenerateToken(claimName, DateTime.UtcNow.AddDays(7));
        }
    }
}