using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class issue2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceIssues_ResolutionModel_ResolutionId",
                table: "MaintenanceIssues");

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
                values: new object[] { "AQAAAAEAACcQAAAAEC3lr3gjdMCNQdAxomsYi8XU30a4mwy1q5cjSNOQ3AduuQ7OcvijB532xPMgImH5LA==", "6ebf99cb-d533-45c9-b326-95cfc5923abe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ResolutionId",
                table: "MaintenanceIssues",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEPwl/BcIbycR1ByLwEIkvo4qmBYZlYV8V9hSGjZ9pxdEVwmlPIFOW0Q4dPTJQO7ATg==", "e30f05b2-419c-4ee2-aa8d-1e50286d84a9" });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceIssues_ResolutionId",
                table: "MaintenanceIssues",
                column: "ResolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceIssues_ResolutionModel_ResolutionId",
                table: "MaintenanceIssues",
                column: "ResolutionId",
                principalTable: "ResolutionModel",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
