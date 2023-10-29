using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace server.Database.Migrations
{
    public partial class CreateUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .CreateTable(
                    name: "User",
                    columns: table =>
                        new
                        {
                            Id = table
                                .Column<int>(type: "int", nullable: false)
                                .Annotation(
                                    "MySql:ValueGenerationStrategy",
                                    MySqlValueGenerationStrategy.IdentityColumn
                                ),
                            FirstName = table
                                .Column<string>(
                                    type: "longtext",
                                    nullable: true,
                                    collation: "utf8mb4_0900_ai_ci"
                                )
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            LastName = table
                                .Column<string>(
                                    type: "longtext",
                                    nullable: true,
                                    collation: "utf8mb4_0900_ai_ci"
                                )
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Number = table
                                .Column<string>(
                                    type: "longtext",
                                    nullable: true,
                                    collation: "utf8mb4_0900_ai_ci"
                                )
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Birthday = table.Column<DateTime>(
                                type: "datetime(6)",
                                maxLength: 6,
                                nullable: true
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
                            DeletedAt = table.Column<DateTime>(
                                type: "datetime(6)",
                                maxLength: 6,
                                nullable: true
                            ),
                            Email = table
                                .Column<string>(
                                    type: "longtext",
                                    nullable: false,
                                    collation: "utf8mb4_0900_ai_ci"
                                )
                                .Annotation("MySql:CharSet", "utf8mb4"),
                            Password = table
                                .Column<string>(
                                    type: "varchar(150)",
                                    maxLength: 150,
                                    nullable: false,
                                    collation: "utf8mb4_0900_ai_ci"
                                )
                                .Annotation("MySql:CharSet", "utf8mb4")
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
