using GWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<UserModel> Users { get; set; }
        public DbSet<ScoreModel> Scores { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}