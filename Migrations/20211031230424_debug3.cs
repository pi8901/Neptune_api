using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Neptune.Migrations
{
    public partial class debug3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "archived",
                table: "test");

            migrationBuilder.DropColumn(
                name: "created",
                table: "test");

            migrationBuilder.DropColumn(
                name: "updated",
                table: "test");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "archived",
                table: "test",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<byte[]>(
                name: "created",
                table: "test",
                type: "BLOB",
                rowVersion: true,
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "updated",
                table: "test",
                type: "BLOB",
                rowVersion: true,
                nullable: true);
        }
    }
}
