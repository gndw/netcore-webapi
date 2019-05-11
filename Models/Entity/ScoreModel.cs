using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWebAPI.Models
{
    [Table("tbl_score")]
    public class ScoreModel : EntityModel
    {
        [Required(ErrorMessage = "Please input Score Value")]
        [Column("value")]
        public int Value { get; set; }

        [Required(ErrorMessage = "Please input UserID")]
        [Column("user_id")]
        [ForeignKey("UserModel")]
        public long UserID { get; set; }

        [ForeignKey("UserID")]
        public UserModel User { get; set; }
    }
}