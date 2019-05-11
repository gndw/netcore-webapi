using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWebAPI.Models
{
    [Table("tbl_user")]
    public class UserModel : EntityModel
    {
        [Required]
        [MinLength(1)]
        [Column("username", TypeName = "varchar(50)")]
        public string Username { get; set; }

        [Required]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        [Column("email", TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required]
        [Column("password", TypeName = "varchar(50)")]
        public string Password { get; set; }
    }
}