using System.Linq;
using GWebAPI.Models;

namespace GWebAPI.Data
{
    public static class DbInitializer
    {
        public static void Initialize(InitializeContext context)
        {
            context.Database.EnsureCreated();

            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User () {Username="gndw",Email="ganda@mail.com",Password="123456"}
            };

            foreach (var user in users)
            {
                context.Users.Add(user);
            }

            context.SaveChanges();
        }
    }
}