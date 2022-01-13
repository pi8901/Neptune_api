using Microsoft.EntityFrameworkCore.Migrations;

namespace Neptune.Migrations
{
    public partial class option_value : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "value",
                table: "options",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "value",
                table: "options");
        }
    }
}
