using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWebAPI.Models
{
    public class UserModel : BaseEntityModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
        [MinLength(1)]
        [Column("username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [Column("email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Column("password")]
        public string Password { get; set; }
    }
}