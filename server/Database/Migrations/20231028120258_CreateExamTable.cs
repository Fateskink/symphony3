using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Database.Migrations
{
    public partial class CreateExamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .CreateTable(
                    name: "Exam",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn
                                ),
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
                            Term = table
                                .Column<string>(
                                    type: "varchar(255)",
                                    maxLength: 255,
                                    nullable: false,
                                    collation: "utf8mb4_0900_ai_ci"
                                )
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Subject = table
                                .Column<string>(
                                    type: "varchar(255)",
                                    maxLength: 255,
                                    nullable: false,
                                    collation: "utf8mb4_0900_ai_ci"
                                )
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Author = table
                                .Column<string>(
                                    type: "varchar(255)",
                                    maxLength: 255,
                                    nullable: false,
                                    collation: "utf8mb4_0900_ai_ci"
                                )
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Time = table.Column<int>(type: "int", nullable: false)
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
