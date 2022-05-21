using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class resolution4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAENJjYK3a3K+7YuzSCUuPzsxm9CNmNlTIs5WWwZawxtgecUyM99+iydhLAwsTsMhyHA==", "b83c5849-74e9-459f-9643-e19c28b01326" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEDcJPnwpXrhOQ0FRjg1bXwZKSDLahk/6sszzPCXv8ICahCitMkekpEotOLslgKWBIA==", "1a9e4262-ed9d-4139-babb-92f6dbebf499" });
        }
    }
}
