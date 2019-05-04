using GWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GWebAPI.Data
{
    public class LeaderboardContext : DbContext
    {
        public LeaderboardContext (DbContextOptions<LeaderboardContext> options) : base(options) {}

        public DbSet<Leaderboard> Leaderboards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Leaderboard>().ToTable("Leaderboard");
        }
    }
}