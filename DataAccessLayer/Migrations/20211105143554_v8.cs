using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2bc5d5a1-3242-4171-9243-6208ca3b404b", "6d04711d-93da-4a68-ba2f-e4adaa5fe823", "SuperAdmin", "SUPERADMIN" },
                    { "e594c207-431f-4874-8097-7f03aee29dd4", "2838a3a1-aa8c-43ab-ad01-5ec97eb3d37e", "Admin", "ADMIN" },
                    { "25bdee72-a387-4e15-9353-a557b3cdcc9d", "425fa089-bc2f-4496-875c-9bc28a957ba9", "Gestor", "GESTOR" },
                    { "12419e75-3355-42f7-9fb8-8f6ab6d6d9f9", "6c3a6e39-611f-42af-9747-090ef50481b3", "Portero", "PORTERO" },
                    { "2ddc010a-3ff5-4b6e-aa95-414c72b3f94b", "bb3f46d4-66c2-4427-bb4d-6d4f1cb46cf3", "Persona", "PERSONA" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "12419e75-3355-42f7-9fb8-8f6ab6d6d9f9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "25bdee72-a387-4e15-9353-a557b3cdcc9d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2bc5d5a1-3242-4171-9243-6208ca3b404b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2ddc010a-3ff5-4b6e-aa95-414c72b3f94b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e594c207-431f-4874-8097-7f03aee29dd4");

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
    }
}
