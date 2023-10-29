namespace server.Models;

public partial class User : BaseModel
{
    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? Number { get; set; }

    public DateTime? Birthday { get; set; }

    public DateTime? DeletedAt { get; set; }

    public string Email { get; set; } = null!;

    public string Password { get; set; } = null!;

    public virtual ICollection<UserCourse> UserCourses { get; set; }

    public User()
    {
        UserCourses = new List<UserCourse>();
    }
}
