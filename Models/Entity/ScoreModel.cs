using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWebAPI.Models
{
    [Table("tbl_score")]
    public class ScoreModel : EntityModel
    {
        [Required]
        [Column("value")]
        public int Value { get; set; }

        [Required]
        [Column("user_id")]
        [ForeignKey("UserModel")]
        public long UserID { get; set; }

        [ForeignKey("UserID")]
        public UserModel User { get; set; }
    }
}