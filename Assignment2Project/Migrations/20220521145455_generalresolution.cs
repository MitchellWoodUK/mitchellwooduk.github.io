using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class generalresolution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralResolutionModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GeneralIssueId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateResolved = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: false),
                    GeneralIssueModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralResolutionModel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralResolutionModel_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralResolutionModel_GeneralIssues_GeneralIssueModelId",
                        column: x => x.GeneralIssueModelId,
                        principalTable: "GeneralIssues",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEKq6iRCmEQ8piqKqP5ie1brxm8cqYHZKMyRkNpKgErIiXRHw9JiwLMqV5PR3TSCDrw==", "0e5c6b2c-b2ae-4677-9e5c-4b84162c68eb" });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralResolutionModel_GeneralIssueModelId",
                table: "GeneralResolutionModel",
                column: "GeneralIssueModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralResolutionModel_UserId",
                table: "GeneralResolutionModel",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralResolutionModel");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEDmbzN7kMftPV+WtIlqR7hTvZwJ4ftYm/mE9Cr0avCzehXZo0pNZyxMSu7YCrT1L8g==", "58785a31-9772-4023-8a0b-ee633ab6a0cb" });
        }
    }
}
