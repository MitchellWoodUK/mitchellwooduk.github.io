using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class maintentanceissue3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEBsnwSCoaqzMO2jHpkYjGr568mRaYALZHb0vZhkaE46GMH4jIPAQ8rloerbG7bj0Pw==", "8620575d-2220-464e-94fc-0762712fb6d6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEFko9qYFtF+hi/L9EfpZ6u++3bEtdzr9e47Ml78HDH6jI2y7AeCGO1fHwxUPf9tPWw==", "85d6fee7-5f5f-4f5d-a9e3-9496885c10ff" });
        }
    }
}
