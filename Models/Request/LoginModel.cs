using GWebAPI.Helpers;

namespace GWebAPI.Models
{
    public class LoginModel : RequestModel
    {
        [Required]
        [Length(4,50)]
        public string Username { get; set; }
        
        [Required]
        [Length(0,50)]
        public string Password { get; set; }
    }
}