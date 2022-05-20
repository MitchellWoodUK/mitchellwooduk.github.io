using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class issue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEPwl/BcIbycR1ByLwEIkvo4qmBYZlYV8V9hSGjZ9pxdEVwmlPIFOW0Q4dPTJQO7ATg==", "e30f05b2-419c-4ee2-aa8d-1e50286d84a9" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEEd7pt/kCzGu3r6l/bRQ90+HVljAVgvkqqf2qhuBEI4jJxBbW5UT2RC0kFrmUnoA6g==", "153aef4c-99f2-4426-8a2d-011e28597a12" });
        }
    }
}
