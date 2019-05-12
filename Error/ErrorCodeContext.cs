using System.Collections.Generic;

namespace GWebAPI.Models
{
    public static class ErrorCodeContext
    {
        public static string GetServerCode (string code)
        {
            string result = string.Empty;
            _context.TryGetValue(code, out result);
            return result;
        }

        private static Dictionary<string,string> _context = new Dictionary<string,string>()
        {
            // Request
            { ErrorCode.RequestFieldUnspecified, "2001" },
            { ErrorCode.InvalidRequestValue, "2002" },
            { ErrorCode.RequestInternalError, "2003" },
            { ErrorCode.InvalidEmailFormat, "2004" },
            
            // Login Register Logout
            { ErrorCode.InvalidUsernameOrPassword, "3001" },
            { ErrorCode.UsernameAlreadyTaken, "3002" },
            { ErrorCode.EmailAlreadyTaken, "3003" }
            
        };
    }
}