namespace GWebAPI.Models
{
    public class ValidationModel : IErrorSource
    {
        public bool IsValid {get; set;}
        public string Code {get; set;}
        public string Message {get; set;}
        public InnerError InnerError {get; set;}
    }
}