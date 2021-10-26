using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class WebAPIv1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "34a98e09-805f-40e7-9a4d-06553dc02f10");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4cc2b18d-acbd-41cc-ac0d-af2fa6263b5f");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7fd750c0-8769-46ca-a76e-410139f96899");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c0b550a3-769d-4715-a7ae-6d1ee5ac2408");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5f232267-e243-4d5e-a956-8abb3386e4bf", "e3554eb3-614a-4811-8a18-b0626dcf948e", "SuperAdmin", "SUPERADMIN" },
                    { "fae0ea2e-29cb-4a31-b8ed-1ff2169d1ae7", "cd7c39c8-fad3-4ba8-a0eb-e7efc506a97f", "Admin", "ADMIN" },
                    { "c8be4332-9789-4f4d-81a9-c0f355ca9591", "c986973d-43ce-4bb7-8f17-b7b5185d7c3c", "Gestor", "GESTOR" },
                    { "5ba54b07-8a7a-40a8-a281-4efb39ecada6", "a31c81c6-5104-4462-8a07-42ff97d5f2bf", "Portero", "PORTERO" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5ba54b07-8a7a-40a8-a281-4efb39ecada6");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5f232267-e243-4d5e-a956-8abb3386e4bf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c8be4332-9789-4f4d-81a9-c0f355ca9591");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fae0ea2e-29cb-4a31-b8ed-1ff2169d1ae7");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "34a98e09-805f-40e7-9a4d-06553dc02f10", "8ad58d3b-85d4-488d-a1e8-f1891d22735a", "SuperAdmin", "SUPERADMIN" },
                    { "7fd750c0-8769-46ca-a76e-410139f96899", "35d6b8d0-a4d4-48b6-b68b-d32f70347878", "Admin", "ADMIN" },
                    { "c0b550a3-769d-4715-a7ae-6d1ee5ac2408", "823a8ab7-738f-4183-b66f-eafaa8a7e460", "Gestor", "GESTOR" },
                    { "4cc2b18d-acbd-41cc-ac0d-af2fa6263b5f", "eccd89a5-7ff6-4f51-9819-fcbd55701cf4", "Portero", "PORTERO" }
                });
        }
    }
}
