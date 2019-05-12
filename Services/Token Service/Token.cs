using System;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace GWebAPI.Services
{
    public class Token
    {
        public Token (SecurityToken securityToken)
        {
            SecurityToken = securityToken;
        }

        public SecurityToken SecurityToken { get; private set; }
        
        public string StringToken { 
            get {
                var tokenHandler = new JwtSecurityTokenHandler();
                return tokenHandler.WriteToken(SecurityToken);
                }
            private set {}}
            
        public DateTime Expires {
            get { 
                return SecurityToken.ValidTo;
                }
            private set {}}
        
    }
}