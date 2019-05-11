namespace GWebAPI.Models
{
    public class ErrorBuilder
    {
        public static object Create (string code, string msg)
        {
            return new {
                error = new ErrorModel()
                {
                    code = code,
                    message = msg
                }
            };
        }

        public static object Create (string code)
        {
            return Create(code, "");
        }

        public static object Create (ErrorCode code, string msg)
        {
            return Create(code.ToString(), msg);
        }

        public static object Create (ErrorCode code)
        {
            return Create(code, "");
        }

        public static object Create (IErrorSource errorSource)
        {
            return Create(errorSource.Code, errorSource.Message);
        }
    }
}