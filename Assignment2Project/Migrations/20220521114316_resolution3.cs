using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class resolution3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceIssues_Resolutions_ResolutionId",
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
                values: new object[] { "AQAAAAEAACcQAAAAEDcJPnwpXrhOQ0FRjg1bXwZKSDLahk/6sszzPCXv8ICahCitMkekpEotOLslgKWBIA==", "1a9e4262-ed9d-4139-babb-92f6dbebf499" });
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
                values: new object[] { "AQAAAAEAACcQAAAAEGME4lquJ0UAcsMrU+4z/To5jmTMeYokBg1BGCytywECFAepH5H2Ynp/riQNbG8+DA==", "82c31abf-487a-4458-abfd-96f36ff7323a" });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceIssues_ResolutionId",
                table: "MaintenanceIssues",
                column: "ResolutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceIssues_Resolutions_ResolutionId",
                table: "MaintenanceIssues",
                column: "ResolutionId",
                principalTable: "Resolutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
