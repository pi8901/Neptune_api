using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Neptune.Migrations
{
    public partial class Initiate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "options",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    datatype = table.Column<int>(type: "INTEGER", nullable: false),
                    archived = table.Column<bool>(type: "INTEGER", nullable: false),
                    created = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    updated = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_options", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "parameter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ParameterId = table.Column<int>(type: "INTEGER", nullable: true),
                    archived = table.Column<bool>(type: "INTEGER", nullable: false),
                    created = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    updated = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_parameter_parameter_ParameterId",
                        column: x => x.ParameterId,
                        principalTable: "parameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    display_name = table.Column<string>(type: "TEXT", nullable: true),
                    permissions = table.Column<int>(type: "INTEGER", nullable: false),
                    archived = table.Column<bool>(type: "INTEGER", nullable: false),
                    created = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    updated = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.username);
                });

            migrationBuilder.CreateTable(
                name: "OptionParameter",
                columns: table => new
                {
                    optionsId = table.Column<int>(type: "INTEGER", nullable: false),
                    parameterId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OptionParameter", x => new { x.optionsId, x.parameterId });
                    table.ForeignKey(
                        name: "FK_OptionParameter_options_optionsId",
                        column: x => x.optionsId,
                        principalTable: "options",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OptionParameter_parameter_parameterId",
                        column: x => x.parameterId,
                        principalTable: "parameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "scripts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    type = table.Column<string>(type: "TEXT", nullable: true),
                    username = table.Column<string>(type: "TEXT", nullable: true),
                    archived = table.Column<bool>(type: "INTEGER", nullable: false),
                    created = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    updated = table.Column<byte[]>(type: "BLOB", rowVersion: true, nullable: true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scripts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_scripts_user_username",
                        column: x => x.username,
                        principalTable: "user",
                        principalColumn: "username",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ParameterScript",
                columns: table => new
                {
                    parameterId = table.Column<int>(type: "INTEGER", nullable: false),
                    scriptsId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterScript", x => new { x.parameterId, x.scriptsId });
                    table.ForeignKey(
                        name: "FK_ParameterScript_parameter_parameterId",
                        column: x => x.parameterId,
                        principalTable: "parameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParameterScript_scripts_scriptsId",
                        column: x => x.scriptsId,
                        principalTable: "scripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OptionParameter_parameterId",
                table: "OptionParameter",
                column: "parameterId");

            migrationBuilder.CreateIndex(
                name: "IX_parameter_ParameterId",
                table: "parameter",
                column: "ParameterId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterScript_scriptsId",
                table: "ParameterScript",
                column: "scriptsId");

            migrationBuilder.CreateIndex(
                name: "IX_scripts_username",
                table: "scripts",
                column: "username");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OptionParameter");

            migrationBuilder.DropTable(
                name: "ParameterScript");

            migrationBuilder.DropTable(
                name: "options");

            migrationBuilder.DropTable(
                name: "parameter");

            migrationBuilder.DropTable(
                name: "scripts");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
