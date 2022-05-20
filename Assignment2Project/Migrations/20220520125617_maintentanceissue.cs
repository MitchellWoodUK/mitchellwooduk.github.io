using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class maintentanceissue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "MaintenanceIssues",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEAp0khyV8/1EmpPQRXNWQD9Y9grC11cxOqyiUuz2RJPsYCXernBYORgvl960Z0OLVw==", "d6c61e1e-276f-4751-9e7a-ca906b7bd2a7" });

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceIssues_RoomId",
                table: "MaintenanceIssues",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintenanceIssues_Rooms_RoomId",
                table: "MaintenanceIssues",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintenanceIssues_Rooms_RoomId",
                table: "MaintenanceIssues");

            migrationBuilder.DropIndex(
                name: "IX_MaintenanceIssues_RoomId",
                table: "MaintenanceIssues");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "MaintenanceIssues");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEL6yIddmWjVqygfT4eFNvCPYyEyiwcM81UtOrSp6fcKcw674fWAe2oi3a4Uu8MZOEA==", "34625a5c-7a0f-49bf-b389-a1e529fc4fe5" });
        }
    }
}
