using GWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace GWebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options) : base(options) {}

        public DbSet<UserModel> Users { get; set; }
        public DbSet<StoryModel> Stories { get; set; }
        public DbSet<LikeStoryModel> StoryLikes { get; set; }
        public DbSet<DislikeStoryModel> StoryDislikes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}