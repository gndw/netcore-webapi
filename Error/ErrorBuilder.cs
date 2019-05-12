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

        public static object Create (IErrorSource errorsource)
        {
            return Create(errorsource.Code, errorsource.Message);
        }
    }
}