using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class resolution : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResolutionId",
                table: "MaintenanceIssues",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Resolutions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaintenanceIssueId = table.Column<int>(type: "INTEGER", nullable: false),
                    DateResolved = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Resolutions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Resolutions_AspNetUsers_UserId",
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
                values: new object[] { "AQAAAAEAACcQAAAAEPXFoCduSZhtlTWaJO1p6SqPUOaOzxiDtlduieSvr8vlJCDem183Q1ijl2QTIu4qkw==", "cbdd0dea-77e4-4b1b-a296-5cd4851eb25d" });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceIssues_ResolutionId",
                table: "MaintenanceIssues",
                column: "ResolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_Resolutions_UserId",
                table: "Resolutions",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceIssues_Resolutions_ResolutionId",
                table: "MaintenanceIssues",
                column: "ResolutionId",
                principalTable: "Resolutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceIssues_Resolutions_ResolutionId",
                table: "MaintenanceIssues");

            migrationBuilder.DropTable(
                name: "Resolutions");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceIssues_ResolutionId",
                table: "MaintenanceIssues");

            migrationBuilder.DropColumn(
                name: "ResolutionId",
                table: "MaintenanceIssues");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEDVEobnjSiVWt5QVkANE+KFjO4v2xL4Yj5K1LnP8D7zlsEcUGUpk2cgpym+ZpK2wSA==", "44796107-3ecb-41ba-869d-ddaf3964ecce" });
        }
    }
}
