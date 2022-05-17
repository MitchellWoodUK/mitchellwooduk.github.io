using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class @int : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEG5FIDHUq/sNlDEIStHfap+HQHIEcJTvWK7MyhbOAknGkdhUoIehaPryyqvv/QdxKg==", "3b1f7544-f4c6-4d45-b528-9b3ba690015d" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEByrEbYfIrEMRDX+h0yJUEUez3bCdOQDHeFGPyvdJ2c3xh9YKzPdOphHznYpuL2ntQ==", "ed8572a8-16a1-4610-8b7f-7b9cbc282db4" });
        }
    }
}
