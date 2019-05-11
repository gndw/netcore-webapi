namespace GWebAPI.Models
{
    public class ErrorModel
    {
        public string code;
        public string message;
        public InnerError innerError;
    }

    public class InnerError
    {
        public string code;
        public InnerError innerError;
    }
}