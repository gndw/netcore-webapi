namespace GWebAPI.Models
{
    public class Leaderboard
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public long Score { get; set; }

        public User User { get; set; }
    }
}