using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWebAPI.Models
{
    [Table("tbl_story")]
    public class StoryModel : EntityModel
    {
        [Required]
        [Column("story_data")]
        public string StoryData { get; set; }

        [Required]
        [Column("creator_user_id")]
        [ForeignKey("UserModel")]
        public long CreatorUserID { get; set; }

        [ForeignKey("CreatorUserID")]
        public UserModel CreatorUser { get; set; }

    }
}