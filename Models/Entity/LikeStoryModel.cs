using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWebAPI.Models
{
    [Table("tbl_story_like")]
    public class LikeStoryModel : EntityModel
    {
        [Required]
        [Column("story_id")]
        [ForeignKey("StoryModel")]
        public long StoryID { get; set; }

        [ForeignKey("StoryID")]
        public StoryModel Story { get; set; }

        [Required]
        [Column("user_id")]
        [ForeignKey("UserModel")]
        public long UserID { get; set; }

        [ForeignKey("UserID")]
        public UserModel User { get; set; }

    }
}