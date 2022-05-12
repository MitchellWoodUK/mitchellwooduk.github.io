using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEJ0XkjxJSwEspXxUQAP+6Xq1kyab1nGXc7JRiDmL6x0ZmUk372/q4M6G6F+ipx8gyQ==", "1ad22855-90f5-4ce4-9bee-208da2d3fb8c" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEF9oRq9N2VHgx+n5A4T6lvyqaHbaR+70Wm2WOFVk+yeX9mN+073SAs5AEFJUKnOq+w==", "ac1d0c2d-b48f-4c0c-9345-aa7ac33e3b07" });
        }
    }
}
