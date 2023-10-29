using Microsoft.EntityFrameworkCore;
using server.Database.Seeders;
using server.Models;

public class DbInitializer
{
    public static void Initialize(SymphonyContext context)
    {
        context.Database.Migrate();

        if (!context.User.Any())
        {
            UserSeeder.Seed(context);
        }

        if (!context.Course.Any())
        {
            CourseSeeder.Seed(context);
        }
    }
}
