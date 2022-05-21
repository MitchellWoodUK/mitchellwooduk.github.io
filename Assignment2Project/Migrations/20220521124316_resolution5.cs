using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class resolution5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MaintenanceIssueModelId",
                table: "Resolutions",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEDmbzN7kMftPV+WtIlqR7hTvZwJ4ftYm/mE9Cr0avCzehXZo0pNZyxMSu7YCrT1L8g==", "58785a31-9772-4023-8a0b-ee633ab6a0cb" });

            migrationBuilder.CreateIndex(
                name: "IX_Resolutions_MaintenanceIssueModelId",
                table: "Resolutions",
                column: "MaintenanceIssueModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resolutions_MaintenanceIssues_MaintenanceIssueModelId",
                table: "Resolutions",
                column: "MaintenanceIssueModelId",
                principalTable: "MaintenanceIssues",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resolutions_MaintenanceIssues_MaintenanceIssueModelId",
                table: "Resolutions");

            migrationBuilder.DropIndex(
                name: "IX_Resolutions_MaintenanceIssueModelId",
                table: "Resolutions");

            migrationBuilder.DropColumn(
                name: "MaintenanceIssueModelId",
                table: "Resolutions");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAENJjYK3a3K+7YuzSCUuPzsxm9CNmNlTIs5WWwZawxtgecUyM99+iydhLAwsTsMhyHA==", "b83c5849-74e9-459f-9643-e19c28b01326" });
        }
    }
}
