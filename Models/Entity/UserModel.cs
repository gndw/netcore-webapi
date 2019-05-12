using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWebAPI.Models
{
    [Table("tbl_user")]
    public class UserModel : EntityModel
    {
        [Required]
        [Column("username", TypeName = "varchar(50)")]
        public string Username { get; set; }

        [Required]
        [Column("email", TypeName = "varchar(50)")]
        public string Email { get; set; }

        [Required]
        [Column("password", TypeName = "varchar(50)")]
        public string Password { get; set; }

        [Required]
        [Column("salt", TypeName = "varchar(50)")]
        public string Salt { get; set; }
    }
}