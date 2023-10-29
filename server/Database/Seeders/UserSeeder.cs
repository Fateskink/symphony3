using server.Models;
using server.Utils;

namespace server.Database.Seeders;

public class UserSeeder
{
    public static void Seed(SymphonyContext context)
    {
        if (!context.User.Any())
        {
            for (int i = 1; i <= 10; i++)
            {
                var user = new User
                {
                    Email = GenerateRandomEmail(),
                    Password = PasswordUtils.EncryptPassword(GenerateRandomNumber()),
                    FirstName = GenerateRandomName(),
                    LastName = GenerateRandomName(),
                    Number = GenerateRandomNumber(),
                    Birthday = DateTime.Now.AddYears(-i),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                context.User.Add(user);
            }
            context.SaveChanges();
        }
    }

    private static string GenerateRandomName()
    {
        return "User" + Guid.NewGuid().ToString("N").Substring(0, 5);
    }

    private static string GenerateRandomNumber()
    {
        Random random = new Random();
        return "0"
            + new string(
                Enumerable.Range(0, 9).Select(_ => random.Next(0, 10).ToString()[0]).ToArray()
            );
    }

    private static string GenerateRandomEmail()
    {
        string firstName = GenerateRandomName();
        string lastName = GenerateRandomName();
        string number = GenerateRandomNumber();
        return $"{firstName}{lastName}{number}@gmail.com";
    }
}
