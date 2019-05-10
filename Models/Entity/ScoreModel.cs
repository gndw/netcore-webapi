using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWebAPI.Models
{
    public class ScoreModel : BaseEntityModel
    {
        [Required(ErrorMessage = "Please input Score Value")]
        [Column("value")]
        public long Value { get; set; }

        [Required(ErrorMessage = "Please input UserID")]
        [Display(Name = "User ID")]
        [Column("user_id")]
        public int UserID { get; set; }

        [ForeignKey("UserID")]
        public UserModel User { get; set; }
    }
}