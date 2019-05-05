using System.ComponentModel.DataAnnotations;

namespace GWebAPI.Models
{
    public class Login
    {
        [Required(ErrorMessage="Username is Required")]
        public string Username { get; set; }

        [Required(ErrorMessage="Password is Required")]
        public string Password { get; set; }
    }
}