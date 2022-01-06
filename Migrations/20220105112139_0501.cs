using Microsoft.EntityFrameworkCore.Migrations;

namespace Neptune.Migrations
{
    public partial class _0501 : Migration
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
                    created = table.Column<string>(type: "TEXT", nullable: true),
                    updated = table.Column<string>(type: "TEXT", nullable: true),
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
                    archived = table.Column<bool>(type: "INTEGER", nullable: false),
                    created = table.Column<string>(type: "TEXT", nullable: true),
                    updated = table.Column<string>(type: "TEXT", nullable: true),
                    title = table.Column<string>(type: "TEXT", nullable: true),
                    description = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_parameter", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    username = table.Column<string>(type: "TEXT", nullable: false),
                    display_name = table.Column<string>(type: "TEXT", nullable: true),
                    permissions = table.Column<int>(type: "INTEGER", nullable: false),
                    archived = table.Column<bool>(type: "INTEGER", nullable: false),
                    created = table.Column<string>(type: "TEXT", nullable: true),
                    updated = table.Column<string>(type: "TEXT", nullable: true)
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
                name: "ParameterParameter",
                columns: table => new
                {
                    parameter_childId = table.Column<int>(type: "INTEGER", nullable: false),
                    parameter_parentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParameterParameter", x => new { x.parameter_childId, x.parameter_parentId });
                    table.ForeignKey(
                        name: "FK_ParameterParameter_parameter_parameter_childId",
                        column: x => x.parameter_childId,
                        principalTable: "parameter",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParameterParameter_parameter_parameter_parentId",
                        column: x => x.parameter_parentId,
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
                    created = table.Column<string>(type: "TEXT", nullable: true),
                    updated = table.Column<string>(type: "TEXT", nullable: true),
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
                name: "scriptParameter_link",
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
                name: "IX_OptionParameter_parameterId",
                table: "OptionParameter",
                column: "parameterId");

            migrationBuilder.CreateIndex(
                name: "IX_ParameterParameter_parameter_parentId",
                table: "ParameterParameter",
                column: "parameter_parentId");

            migrationBuilder.CreateIndex(
                name: "IX_scriptParameter_link_parameterId",
                table: "scriptParameter_link",
                column: "parameterId");

            migrationBuilder.CreateIndex(
                name: "IX_scriptParameter_link_scriptId",
                table: "scriptParameter_link",
                column: "scriptId");

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
                name: "ParameterParameter");

            migrationBuilder.DropTable(
                name: "scriptParameter_link");

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
