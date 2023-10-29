using System.ComponentModel.DataAnnotations;

namespace server.Models;

public partial class UserCourse : BaseModel
{
    [Required]
    public int UserId { get; set; }
    public User? User { get; set; }

    [Required]
    public int CourseId { get; set; }
    public Course? Course { get; set; }
}
