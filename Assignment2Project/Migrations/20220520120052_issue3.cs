using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class issue3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralIssues_ResolutionModel_ResolutionId",
                table: "GeneralIssues");

            migrationBuilder.DropTable(
                name: "ResolutionModel");

            migrationBuilder.DropIndex(
                name: "IX_GeneralIssues_ResolutionId",
                table: "GeneralIssues");

            migrationBuilder.DropColumn(
                name: "ResolutionId",
                table: "GeneralIssues");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEL6yIddmWjVqygfT4eFNvCPYyEyiwcM81UtOrSp6fcKcw674fWAe2oi3a4Uu8MZOEA==", "34625a5c-7a0f-49bf-b389-a1e529fc4fe5" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResolutionId",
                table: "GeneralIssues",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ResolutionModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    DateResolved = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResolutionModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ResolutionModel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEC3lr3gjdMCNQdAxomsYi8XU30a4mwy1q5cjSNOQ3AduuQ7OcvijB532xPMgImH5LA==", "6ebf99cb-d533-45c9-b326-95cfc5923abe" });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralIssues_ResolutionId",
                table: "GeneralIssues",
                column: "ResolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_ResolutionModel_UserId",
                table: "ResolutionModel",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralIssues_ResolutionModel_ResolutionId",
                table: "GeneralIssues",
                column: "ResolutionId",
                principalTable: "ResolutionModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
