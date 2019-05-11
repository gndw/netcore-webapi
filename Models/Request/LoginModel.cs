using GWebAPI.Helpers;

namespace GWebAPI.Models
{
    public class LoginModel : RequestModel
    {
        [RequiredRequest]
        public string Username { get; set; }
        [RequiredRequest]
        public string Password { get; set; }
    }
}