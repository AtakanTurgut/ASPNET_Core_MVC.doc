using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StoreApp.Migrations
{
    public partial class IdentityRoleSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "25c533bc-4ef1-43b1-8bd7-4679ceaa8ab0", "bafc6363-ad67-4fa8-a1bd-feede6f28ae7", "Editor", "EDITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7327cfd2-ad4f-4ef0-9b78-2406145b8b9c", "e6753bf0-525e-4fe6-9e96-fd7491864f1e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "97f1cef3-fcd2-481d-8bf2-71c9e1a86453", "4130ca6a-4634-4e44-a250-2f83a34a6593", "User", "USER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25c533bc-4ef1-43b1-8bd7-4679ceaa8ab0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7327cfd2-ad4f-4ef0-9b78-2406145b8b9c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "97f1cef3-fcd2-481d-8bf2-71c9e1a86453");
        }
    }
}
