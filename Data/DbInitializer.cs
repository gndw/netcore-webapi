using System.Linq;
using GWebAPI.Models;

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

            var users = new UserModel[]
            {
                new UserModel () {Username="gndw",Email="ganda@mail.com",Password="123"}
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}