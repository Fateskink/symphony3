namespace server.Models;

public partial class Exam : BaseModel
{
    public string Term { get; set; } = null!;

    public string Subject { get; set; } = null!;

    public string Author { get; set; } = null!;

    public int Time { get; set; }
}
