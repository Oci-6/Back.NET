using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class WebAPIv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                    { "fdfe4a4e-bd55-4dfc-8d48-3f8e63e82d8b", "f414aac5-7d37-401a-afde-8e919c53344a", "SuperAdmin", "SUPERADMIN" },
                    { "e3a7b19f-5749-4c69-bdc3-0acb5f60a56d", "43bb7137-7f43-4999-9e30-9a827d57e8b0", "Admin", "ADMIN" },
                    { "7983be22-e7f8-4e81-a7b7-a124034fc7aa", "fb1b217d-c03d-410a-850e-5ab74a7fe5ca", "Gestor", "GESTOR" },
                    { "549ae824-b98a-4d06-a66a-a5e5e0bf9a69", "f03412da-981a-4e03-9953-300d6dc51204", "Portero", "PORTERO" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "549ae824-b98a-4d06-a66a-a5e5e0bf9a69");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7983be22-e7f8-4e81-a7b7-a124034fc7aa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e3a7b19f-5749-4c69-bdc3-0acb5f60a56d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "fdfe4a4e-bd55-4dfc-8d48-3f8e63e82d8b");

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
    }
}
