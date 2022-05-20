using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class maintentanceissue2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEFko9qYFtF+hi/L9EfpZ6u++3bEtdzr9e47Ml78HDH6jI2y7AeCGO1fHwxUPf9tPWw==", "85d6fee7-5f5f-4f5d-a9e3-9496885c10ff" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEAp0khyV8/1EmpPQRXNWQD9Y9grC11cxOqyiUuz2RJPsYCXernBYORgvl960Z0OLVw==", "d6c61e1e-276f-4751-9e7a-ca906b7bd2a7" });
        }
    }
}
