using System.ComponentModel.DataAnnotations;

namespace GWebAPI.Models
{
    public class User
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please Enter Name")]
        [MinLength(1)]
        public string Username { get; set; }

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "Please Enter Email")]
        [RegularExpression(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$", ErrorMessage = "Email is not valid.")]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Please Enter Password")]
        public string Password { get; set; }
    }
}