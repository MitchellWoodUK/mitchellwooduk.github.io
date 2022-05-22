using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class finished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEO1Tj9sSN5WkABSZDh17rt0y949atfRorSqJzlF63ZmYTh9P6PzjrenHwlEYlTnGEQ==", "7752520d-4184-428d-ac11-4face6286167" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEKq6iRCmEQ8piqKqP5ie1brxm8cqYHZKMyRkNpKgErIiXRHw9JiwLMqV5PR3TSCDrw==", "0e5c6b2c-b2ae-4677-9e5c-4b84162c68eb" });
        }
    }
}
