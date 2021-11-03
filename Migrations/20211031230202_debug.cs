using Microsoft.EntityFrameworkCore.Migrations;

namespace Neptune.Migrations
{
    public partial class debug : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "implemented",
                table: "parameter",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "implemented",
                table: "parameter");
        }
    }
}
