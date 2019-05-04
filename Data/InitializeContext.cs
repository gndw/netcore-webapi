using GWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GWebAPI.Data
{
    public class InitializeContext : DbContext
    {
        public InitializeContext (DbContextOptions<InitializeContext> options) : base(options) {}

        public DbSet<User> Users { get; set; }
        public DbSet<Leaderboard> Leaderboards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Leaderboard>().ToTable("Leaderboard");
        }
    }
}