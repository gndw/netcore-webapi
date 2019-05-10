using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWebAPI.Models
{
    [Table("tbl_user")]
    public class UserModel : BaseEntityModel
    {
        [Required(ErrorMessage = "Please Enter Name")]
        [MinLength(1)]
        [Column("username", TypeName = "varchar(50)")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [Column("email", TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter Password")]
        [Column("password", TypeName = "varchar(50)")]
        public string Password { get; set; }
    }
}