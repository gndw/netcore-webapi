using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GWebAPI.Models
{
    public class FullStoryModel
    {
        public long StoryID { get; set; }
        public int Likes { get; set; }
        public int Dislikes { get; set; }
    }
}