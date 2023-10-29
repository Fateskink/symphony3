using System.ComponentModel.DataAnnotations;

namespace server.Models;

public partial class BaseModel
{
    [Key]
    public int Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
