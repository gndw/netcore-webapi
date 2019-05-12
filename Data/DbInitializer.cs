using System.Linq;
using GWebAPI.Models;
using GWebAPI.Services;

namespace GWebAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            GwebPasswordHashService phs = new GwebPasswordHashService();
            PasswordHash ph = phs.Generate("123");
            var users = new UserModel[]
            {
                new UserModel () {
                    Username="gndw",
                    Email="ganda@mail.com",
                    Password=ph.Password,
                    Salt=ph.Salt}
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}