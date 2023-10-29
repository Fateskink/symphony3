using server.Models;

namespace server.Database.Seeders;

public class CourseSeeder
{
    public static void Seed(SymphonyContext context)
    {
        if (!context.Course.Any())
        {
            for (int i = 1; i <= 10; i++)
            {
                var course = new Course
                {
                    CourseName = GenerateRandomName(),
                    Major = GenerateRandomName(),
                    Description = GenerateRandomName(),
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };
                context.Course.Add(course);
            }
            context.SaveChanges();
        }
    }

    private static string GenerateRandomName()
    {
        return "Course" + Guid.NewGuid().ToString("N").Substring(0, 5);
    }
}
