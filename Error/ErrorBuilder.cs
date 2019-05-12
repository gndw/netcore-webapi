using System.Text.RegularExpressions;

namespace GWebAPI.Models
{
    public class ErrorBuilder
    {
        public static object Create (string code, string message)
        {
            return new {
                error = new {
                    code = code,
                    message = message,
                    servercode = ErrorCodeContext.GetServerCode(code)
                }
            };
        }

        public static object Create (string code)
        {
            return Create(code, Regex.Replace(code, "([A-Z])", " $1", RegexOptions.Compiled).Trim());
        }

        public static object Create (IErrorSource errorsource)
        {
            return Create(errorsource.Code, errorsource.Message);
        }
    }
}