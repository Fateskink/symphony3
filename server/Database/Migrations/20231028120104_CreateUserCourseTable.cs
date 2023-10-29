using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Database.Migrations
{
    public partial class CreateUserCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .CreateTable(
                    name: "UserCourse",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn
                                ),
                            UserId = table.Column<int>(type: "int", nullable: false),
                            CourseId = table.Column<int>(type: "int", nullable: false),
                            CreatedAt = table.Column<DateTime>(
                                type: "datetime(6)",
                                maxLength: 6,
                                nullable: false
                            ),
                            UpdatedAt = table.Column<DateTime>(
                                type: "datetime(6)",
                                maxLength: 6,
                                nullable: false
                            )
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PRIMARY", x => x.Id);
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");

            migrationBuilder.CreateIndex(
                name: "IX_UserId_CourseId",
                table: "UserCourse",
                columns: new[] { "UserId", "CourseId" },
                unique: true
            );
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
