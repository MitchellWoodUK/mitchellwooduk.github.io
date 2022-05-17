using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class createroom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEIzhsk2RCVc1fIBc4ESsrKUON1QVXtBiIpu/gRhulUus0Ktndamrozx7my1vIMVk+g==", "8fc077aa-ec63-43bc-ba00-380f5fd81d67" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEG5FIDHUq/sNlDEIStHfap+HQHIEcJTvWK7MyhbOAknGkdhUoIehaPryyqvv/QdxKg==", "3b1f7544-f4c6-4d45-b528-9b3ba690015d" });
        }
    }
}
