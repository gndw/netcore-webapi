namespace GWebAPI.Error
{
    public class ErrorModel
    {
        public string code;
        public string message;
        public string target;
        public ErrorModel[] details;
        public InnerError innerError;
        public int servercode;
    }

    public class InnerError
    {
        public string code;
        public InnerError innerError;
    }
}