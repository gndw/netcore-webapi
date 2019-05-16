using GWebAPI.Helpers;

namespace GWebAPI.Models
{
    public class RegisterModel : RequestModel
    {
        [Required]
        [Length(4,50)]
        public string Username { get; set; }

        [Required]
        [Length(0,50)]
        [Email]
        public string Email { get; set; }
        
        [Required]
        [Length(0,50)]
        public string Password { get; set; }
    }
}