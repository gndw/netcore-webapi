namespace GWebAPI.Models
{
    public interface IErrorSource
    {
        string Code {get; set;}
        string Message {get; set;}
    }
}