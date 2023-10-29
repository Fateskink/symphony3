using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace server.Helpers;

public static class MigrationHelpers
{
    public static void CreateCommonColumns(MigrationBuilder migrationBuilder, string tableName)
    {
        migrationBuilder.CreateTable(
            name: tableName,
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                CreatedAt = table.Column<DateTime>(nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", "CURRENT_TIMESTAMP"),
                UpdatedAt = table.Column<DateTime>(nullable: false)
                    .Annotation("MySql:ValueGenerationStrategy", "CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP"),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_" + tableName, x => x.Id);
            }
        );
    }
}
