using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class v2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<string>(
                name: "Apellido",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Documento",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "TipoDocumento",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f7dba5ac-6fb3-495a-bfda-47831cfac94d", "bbe89365-eaad-4567-9277-63eae6c573d0", "SuperAdmin", "SUPERADMIN" },
                    { "5d090c20-0323-4bdf-b650-2ff421547ad2", "91e9f414-9585-413f-a623-8b6894ecda48", "Admin", "ADMIN" },
                    { "f33f0dd9-1edf-4c63-a1b9-56931b48d402", "cd9ae0c9-0917-4e67-8d62-2e3e673f2266", "Gestor", "GESTOR" },
                    { "ebb7f9f7-8484-4a44-a820-eb337e0353c5", "b0ff21e9-78ab-4d91-a92b-af17a28f9a7d", "Portero", "PORTERO" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5d090c20-0323-4bdf-b650-2ff421547ad2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ebb7f9f7-8484-4a44-a820-eb337e0353c5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f33f0dd9-1edf-4c63-a1b9-56931b48d402");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7dba5ac-6fb3-495a-bfda-47831cfac94d");

            migrationBuilder.DropColumn(
                name: "Apellido",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Documento",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TipoDocumento",
                table: "AspNetUsers");

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
    }
}
