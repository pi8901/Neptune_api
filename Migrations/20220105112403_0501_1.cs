using Microsoft.EntityFrameworkCore.Migrations;

namespace Neptune.Migrations
{
    public partial class _0501_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scriptParameter_link");

            migrationBuilder.CreateTable(
                name: "scriptParameter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    implemented = table.Column<bool>(type: "INTEGER", nullable: false),
                    scriptId = table.Column<int>(type: "INTEGER", nullable: true),
                    parameterId = table.Column<int>(type: "INTEGER", nullable: true),
                    archived = table.Column<bool>(type: "INTEGER", nullable: false),
                    created = table.Column<string>(type: "TEXT", nullable: true),
                    updated = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scriptParameter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_scriptParameter_parameter_parameterId",
                        column: x => x.parameterId,
                        principalTable: "parameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scriptParameter_scripts_scriptId",
                        column: x => x.scriptId,
                        principalTable: "scripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_scriptParameter_parameterId",
                table: "scriptParameter",
                column: "parameterId");

            migrationBuilder.CreateIndex(
                name: "IX_scriptParameter_scriptId",
                table: "scriptParameter",
                column: "scriptId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scriptParameter");

            migrationBuilder.CreateTable(
                name: "scriptParameter_link",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    archived = table.Column<bool>(type: "INTEGER", nullable: false),
                    created = table.Column<string>(type: "TEXT", nullable: true),
                    implemented = table.Column<bool>(type: "INTEGER", nullable: false),
                    parameterId = table.Column<int>(type: "INTEGER", nullable: true),
                    scriptId = table.Column<int>(type: "INTEGER", nullable: true),
                    updated = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scriptParameter_link", x => x.Id);
                    table.ForeignKey(
                        name: "FK_scriptParameter_link_parameter_parameterId",
                        column: x => x.parameterId,
                        principalTable: "parameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_scriptParameter_link_scripts_scriptId",
                        column: x => x.scriptId,
                        principalTable: "scripts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_scriptParameter_link_parameterId",
                table: "scriptParameter_link",
                column: "parameterId");

            migrationBuilder.CreateIndex(
                name: "IX_scriptParameter_link_scriptId",
                table: "scriptParameter_link",
                column: "scriptId");
        }
    }
}
