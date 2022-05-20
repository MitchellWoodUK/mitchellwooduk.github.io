using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class issuechnage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEMMr2LC8XSmqiGloDOoEKJTWfwcA5gOd1+GLsfNamxSrrdfgLzJ+X9XSIh8Sedrunw==", "ff4603a7-512e-410a-ba5f-30302ba4ee06" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEBxzY8dagW87PwbzVmRBUwv6x4w2BSuQDAWUEKABr+btK+Hm9+5mxWROYMaHaLWmTw==", "b121c723-2538-4124-be65-1cf5aa99f69b" });
        }
    }
}
