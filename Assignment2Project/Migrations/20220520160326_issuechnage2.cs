using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class issuechnage2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEJmkoFQ0hFvB1Cyjutw3rgf+rcmgaRaHecVaunTjRShRGzeSAqZckdJewCtqMs6Sow==", "a47f6a89-55c0-4bc6-8009-08579c1809e7" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEMMr2LC8XSmqiGloDOoEKJTWfwcA5gOd1+GLsfNamxSrrdfgLzJ+X9XSIh8Sedrunw==", "ff4603a7-512e-410a-ba5f-30302ba4ee06" });
        }
    }
}
