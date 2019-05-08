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
        Token GenerateToken (Claim[] claims, DateTime expires);
        Token GenerateToken (Claim[] claims);
    }

    public class GwebTokenService : IGwebTokenService
    {
        private readonly AppSettings _appSettings;

        public GwebTokenService(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        /// <summary>
        /// Generate JWT Token
        /// </summary>
        public Token GenerateToken (Claim[] claims, DateTime expires)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = expires,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Token(token);
        }

        /// <summary>
        /// Generate JWT Token, expires in 7 days
        /// </summary>
        public Token GenerateToken (Claim[] claims)
        {
            return GenerateToken(claims, DateTime.UtcNow.AddDays(7));
        }
    }
}