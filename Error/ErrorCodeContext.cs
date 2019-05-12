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
            { ErrorCode.RequestFieldUnspecified, "2001" }
        };
    }
}