namespace server.Models;

public partial class Course : BaseModel
{
    public string CourseName { get; set; } = null!;

    public string? Major { get; set; }

    public string? Description { get; set; }

    public DateTime? DeletedAt { get; set; }

    public virtual ICollection<UserCourse> UserCourses { get; set; }

    public Course()
    {
        UserCourses = new List<UserCourse>();
    }
}
