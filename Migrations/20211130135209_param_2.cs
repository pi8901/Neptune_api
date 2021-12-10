using Microsoft.EntityFrameworkCore.Migrations;

namespace Neptune.Migrations
{
    public partial class param_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_parameter_parameter_ParameterId",
                table: "parameter");

            migrationBuilder.DropIndex(
                name: "IX_parameter_ParameterId",
                table: "parameter");

            migrationBuilder.DropColumn(
                name: "ParameterId",
                table: "parameter");

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

            migrationBuilder.CreateIndex(
                name: "IX_ParameterParameter_parameter_parentId",
                table: "ParameterParameter",
                column: "parameter_parentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ParameterParameter");

            migrationBuilder.AddColumn<int>(
                name: "ParameterId",
                table: "parameter",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_parameter_ParameterId",
                table: "parameter",
                column: "ParameterId");

            migrationBuilder.AddForeignKey(
                name: "FK_parameter_parameter_ParameterId",
                table: "parameter",
                column: "ParameterId",
                principalTable: "parameter",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
