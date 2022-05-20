using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class issuevm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEBxzY8dagW87PwbzVmRBUwv6x4w2BSuQDAWUEKABr+btK+Hm9+5mxWROYMaHaLWmTw==", "b121c723-2538-4124-be65-1cf5aa99f69b" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEBsnwSCoaqzMO2jHpkYjGr568mRaYALZHb0vZhkaE46GMH4jIPAQ8rloerbG7bj0Pw==", "8620575d-2220-464e-94fc-0762712fb6d6" });
        }
    }
}
