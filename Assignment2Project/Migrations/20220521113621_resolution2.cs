using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class resolution2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEGME4lquJ0UAcsMrU+4z/To5jmTMeYokBg1BGCytywECFAepH5H2Ynp/riQNbG8+DA==", "82c31abf-487a-4458-abfd-96f36ff7323a" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2",
                columns: new[] { "PasswordHash", "SecurityStamp" },
                values: new object[] { "AQAAAAEAACcQAAAAEPXFoCduSZhtlTWaJO1p6SqPUOaOzxiDtlduieSvr8vlJCDem183Q1ijl2QTIu4qkw==", "cbdd0dea-77e4-4b1b-a296-5cd4851eb25d" });
        }
    }
}
