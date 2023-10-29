using Microsoft.EntityFrameworkCore;
using server.Models.Configs;

namespace server.Models;

public partial class SymphonyContext : DbContext
{
    public SymphonyContext() { }

    public SymphonyContext(DbContextOptions<SymphonyContext> options)
        : base(options)
    {
        DbInitializer.Initialize(this);
    }

    public virtual DbSet<Course> Course { get; set; }

    public virtual DbSet<Exam> Exam { get; set; }

    public virtual DbSet<User> User { get; set; }

    public virtual DbSet<UserCourse> UserCourse { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_0900_ai_ci").HasCharSet("utf8mb4");

        modelBuilder.ApplyConfiguration(new UserCourseConfiguration());

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
