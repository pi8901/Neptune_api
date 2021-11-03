using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Neptune.Migrations
{
    public partial class debug2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "test",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    archived = table.Column<bool>(type: "INTEGER", nullable: false),
                    created = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    updated = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_test", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "test");
        }
    }
}
