using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Database.Migrations
{
    public partial class CreateCourseTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .CreateTable(
                    name: "Course",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn
                                ),
                            CourseName = table
                                .Column<string>(
                                    type: "longtext",
                                    nullable: false,
                                    collation: "utf8mb4_0900_ai_ci"
                                )
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Major = table
                                .Column<string>(
                                    type: "longtext",
                                    nullable: true,
                                    collation: "utf8mb4_0900_ai_ci"
                                )
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Description = table
                                .Column<string>(
                                    type: "longtext",
                                    nullable: true,
                                    collation: "utf8mb4_0900_ai_ci"
                                )
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            CreatedAt = table.Column<DateTime>(
                                type: "datetime(6)",
                                maxLength: 6,
                                nullable: false
                            ),
                            UpdatedAt = table.Column<DateTime>(
                                type: "datetime(6)",
                                maxLength: 6,
                                nullable: false
                            ),
                            DeletedAt = table.Column<DateTime>(
                                type: "datetime(6)",
                                maxLength: 6,
                                nullable: true
                            )
                        },
                    constraints: table =>
                    {
                        table.PrimaryKey("PRIMARY", x => x.Id);
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .Annotation("Relational:Collation", "utf8mb4_0900_ai_ci");
        }

        protected override void Down(MigrationBuilder migrationBuilder) { }
    }
}
