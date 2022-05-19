using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class issues : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "InstitutionId",
                table: "MaintenanceIssues",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "InstitutionId",
                table: "GeneralIssues",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEEd7pt/kCzGu3r6l/bRQ90+HVljAVgvkqqf2qhuBEI4jJxBbW5UT2RC0kFrmUnoA6g==", "153aef4c-99f2-4426-8a2d-011e28597a12" });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceIssues_InstitutionId",
                table: "MaintenanceIssues",
                column: "InstitutionId");

            migrationBuilder.CreateIndex(
                name: "IX_GeneralIssues_InstitutionId",
                table: "GeneralIssues",
                column: "InstitutionId");

            migrationBuilder.AddForeignKey(
                name: "FK_GeneralIssues_Institutions_InstitutionId",
                table: "GeneralIssues",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceIssues_Institutions_InstitutionId",
                table: "MaintenanceIssues",
                column: "InstitutionId",
                principalTable: "Institutions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_GeneralIssues_Institutions_InstitutionId",
                table: "GeneralIssues");

            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceIssues_Institutions_InstitutionId",
                table: "MaintenanceIssues");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceIssues_InstitutionId",
                table: "MaintenanceIssues");

            migrationBuilder.DropIndex(
                name: "IX_GeneralIssues_InstitutionId",
                table: "GeneralIssues");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "MaintenanceIssues");

            migrationBuilder.DropColumn(
                name: "InstitutionId",
                table: "GeneralIssues");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAELENyk9UVmakePPV1E0XtPZZisKaEj6xgsHJc2SVC3m2ZEDrxOvm8qLbNJc87Cy/GQ==", "dc9515de-960c-4a59-865c-698b2003b9ce" });
        }
    }
}
