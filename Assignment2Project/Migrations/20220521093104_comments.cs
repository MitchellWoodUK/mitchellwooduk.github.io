using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class comments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneralComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    GeneralIssueId = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    GeneralIssueModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralComments_GeneralIssues_GeneralIssueModelId",
                        column: x => x.GeneralIssueModelId,
                        principalTable: "GeneralIssues",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceComments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MaintenanceIssueId = table.Column<int>(type: "INTEGER", nullable: false),
                    Comment = table.Column<string>(type: "TEXT", nullable: false),
                    TimeStamp = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    MaintenanceIssueModelId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceComments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceComments_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceComments_MaintenanceIssues_MaintenanceIssueModelId",
                        column: x => x.MaintenanceIssueModelId,
                        principalTable: "MaintenanceIssues",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEDVEobnjSiVWt5QVkANE+KFjO4v2xL4Yj5K1LnP8D7zlsEcUGUpk2cgpym+ZpK2wSA==", "44796107-3ecb-41ba-869d-ddaf3964ecce" });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralComments_GeneralIssueModelId",
                table: "GeneralComments",
                column: "GeneralIssueModelId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralComments_UserId",
                table: "GeneralComments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceComments_MaintenanceIssueModelId",
                table: "MaintenanceComments",
                column: "MaintenanceIssueModelId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceComments_UserId",
                table: "MaintenanceComments",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralComments");

            migrationBuilder.DropTable(
                name: "MaintenanceComments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEJmkoFQ0hFvB1Cyjutw3rgf+rcmgaRaHecVaunTjRShRGzeSAqZckdJewCtqMs6Sow==", "a47f6a89-55c0-4bc6-8009-08579c1809e7" });
        }
    }
}
