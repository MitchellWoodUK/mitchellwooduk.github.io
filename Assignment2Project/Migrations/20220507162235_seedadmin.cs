using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Assignment2Project.Migrations
{
    public partial class seedadmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "1a43ecdc-e161-4cc2-8476-004e461304fd", "48c7b087-13b9-46bd-b10f-9566e89276ab", "Estates_Admin", "ESTATES_ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "35981c10-0352-46be-9b0b-769ce6d85af9", "16e1cc37-4269-4096-880c-53b14399beff", "Institution_Staff", "INSTITUTION_STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "875ea618-c65e-4eac-9c0f-4a59f1ddaa2c", "7684f586-4a4d-4b14-b09c-a1a936cd4c8d", "Estates_Staff", "ESTATES_STAFF" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "fd32bd40-c6ba-474a-b959-55a3a8941347", "3a8cfa8f-22b3-4323-ae1a-11884ac4ba6d", "Institution_Manager", "INSTITUTION_MANAGER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "Fname", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Sname", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1a4df6c2-e479-40eb-8135-d492174424f2", 0, "76a518b4-92f0-4b97-b4c2-86bb109ef976", "admin@estates.com", false, "Admin", false, null, "ADMIN@ESTATES.COM", "ADMIN@ESTATES.COM", "AQAAAAEAACcQAAAAEI16wXriiTCcl/HwhndJA9lGVkCDfHAITqY2SfKgdWRtiFIP78//+L37g74Dg8t5PA==", null, false, "2989f79b-ebb6-4a67-b474-072f15728c64", "Admin", false, "admin@estates.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1a43ecdc-e161-4cc2-8476-004e461304fd", "1a4df6c2-e479-40eb-8135-d492174424f2" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "35981c10-0352-46be-9b0b-769ce6d85af9", "1a4df6c2-e479-40eb-8135-d492174424f2" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "875ea618-c65e-4eac-9c0f-4a59f1ddaa2c", "1a4df6c2-e479-40eb-8135-d492174424f2" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "fd32bd40-c6ba-474a-b959-55a3a8941347", "1a4df6c2-e479-40eb-8135-d492174424f2" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1a43ecdc-e161-4cc2-8476-004e461304fd", "1a4df6c2-e479-40eb-8135-d492174424f2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "35981c10-0352-46be-9b0b-769ce6d85af9", "1a4df6c2-e479-40eb-8135-d492174424f2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "875ea618-c65e-4eac-9c0f-4a59f1ddaa2c", "1a4df6c2-e479-40eb-8135-d492174424f2" });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "fd32bd40-c6ba-474a-b959-55a3a8941347", "1a4df6c2-e479-40eb-8135-d492174424f2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a43ecdc-e161-4cc2-8476-004e461304fd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "35981c10-0352-46be-9b0b-769ce6d85af9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "875ea618-c65e-4eac-9c0f-4a59f1ddaa2c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fd32bd40-c6ba-474a-b959-55a3a8941347");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1a4df6c2-e479-40eb-8135-d492174424f2");
        }
    }
}
