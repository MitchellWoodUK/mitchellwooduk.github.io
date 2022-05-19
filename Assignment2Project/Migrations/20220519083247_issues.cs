using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class issues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResolutionModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateResolved = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "GeneralIssues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateRaised = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: false),
                    IsResolved = table.Column<bool>(type: "INTEGER", nullable: false),
                    ResolutionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GeneralIssues_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GeneralIssues_ResolutionModel_ResolutionId",
                        column: x => x.ResolutionId,
                        principalTable: "ResolutionModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceIssues",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    TimeRaised = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UserId = table.Column<string>(type: "TEXT", nullable: false),
                    Details = table.Column<string>(type: "TEXT", nullable: false),
                    AssetId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsResolved = table.Column<bool>(type: "INTEGER", nullable: false),
                    ResolutionId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceIssues", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceIssues_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceIssues_Assets_AssetId",
                        column: x => x.AssetId,
                        principalTable: "Assets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceIssues_ResolutionModel_ResolutionId",
                        column: x => x.ResolutionId,
                        principalTable: "ResolutionModel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEG3+Q0PjUTQTnzh2QpBgVU+d4VtHfsDXDr7frdzQNCq2S/n2svCDf7eV7q/uZ6Ac3g==", "3333db26-bdb6-4fa8-8e18-43ce63e56807" });

            migrationBuilder.CreateIndex(
                name: "IX_GeneralIssues_ResolutionId",
                table: "GeneralIssues",
                column: "ResolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralIssues_UserId",
                table: "GeneralIssues",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceIssues_AssetId",
                table: "MaintenanceIssues",
                column: "AssetId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceIssues_ResolutionId",
                table: "MaintenanceIssues",
                column: "ResolutionId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceIssues_UserId",
                table: "MaintenanceIssues",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ResolutionModel_UserId",
                table: "ResolutionModel",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GeneralIssues");

            migrationBuilder.DropTable(
                name: "MaintenanceIssues");

            migrationBuilder.DropTable(
                name: "ResolutionModel");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAECnW3OnNsKwlS1RMtgLNCREFBsogMLunmMbQO1lsQrxJJ4oQYOwWitxHbxctkNfIBw==", "03a6a04d-5612-4611-a6db-1feca13f13a7" });
        }
    }
}
