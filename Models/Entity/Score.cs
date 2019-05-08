using System.ComponentModel.DataAnnotations;

namespace GWebAPI.Models
{
    public class Score
    {
        [ScaffoldColumn(false)]
        public int ID { get; set; }

        [Required(ErrorMessage = "Please input UserID")]
        [Display(Name = "User ID")]
        public int UserID { get; set; }

        [Required(ErrorMessage = "Please input Score Value")]
        public long Value { get; set; }

        public User User { get; set; }
    }
}