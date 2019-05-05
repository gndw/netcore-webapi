using System.ComponentModel.DataAnnotations;

namespace GWebAPI.Models
{
    public class Leaderboard
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please input UserID")]
        [Display(Name = "User ID")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please input Score")]
        public long Score { get; set; }

        public User User { get; set; }
    }
}