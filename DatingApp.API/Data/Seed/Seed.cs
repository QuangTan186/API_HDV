using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using DatingApp.API.Data.Entities;
using System.Security.Cryptography;
using System.Text;

namespace DatingApp.API.Data.Seed
{
    public class Seed
    {
        public static void SeedUser(DataContext context)
        {
            if(context.AppUsers.Any()) return;

            var usersText = System.IO.File.ReadAllText("Data/Seed/user.json");
            var users = JsonSerializer.Deserialize<List<User>>(usersText);

            foreach(var user in users)
            {
                using var hmac = new HMACSHA512();
                user.PasswordSalt = hmac.Key;
                user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes("P@$$w0rd1"));
                user.CreateAt = DateTime.Now;

                context.AppUsers.Add(user);
            }
            context.SaveChanges();
        }
    }
}