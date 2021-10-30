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
                keyValue: "1eedc8f8-cf9d-47ef-8b90-4c5cdd9a0e62");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9792803a-5a32-444e-95b0-1df840e4c606");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "9bcea184-f1cb-4d4f-9c77-1abacc708999");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bfea6005-6e38-48a8-958e-ea6625ef0d7a");

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Puertas",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "a286dc77-c2da-47da-ab2c-09f8a158a525", "c64054e6-e121-4374-a0dc-12f27ea24ec8", "SuperAdmin", "SUPERADMIN" },
                    { "0e068ca1-c22d-48df-a43c-a07f9c1f81e0", "30a115f0-f6d2-4b45-b469-06b823650150", "Admin", "ADMIN" },
                    { "7e132e3b-5b5d-4e6b-b948-9ff0fa661fd5", "c205d864-b74e-458f-8989-2d81a9e49166", "Gestor", "GESTOR" },
                    { "294b90b3-696b-40f0-ac43-fe07047b1e15", "a8df60c5-7a66-4e28-a510-e37ae05f27f5", "Portero", "PORTERO" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e068ca1-c22d-48df-a43c-a07f9c1f81e0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "294b90b3-696b-40f0-ac43-fe07047b1e15");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e132e3b-5b5d-4e6b-b948-9ff0fa661fd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a286dc77-c2da-47da-ab2c-09f8a158a525");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Puertas");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "9792803a-5a32-444e-95b0-1df840e4c606", "f716c8fe-c7c5-4938-8f48-2e5341766fdb", "SuperAdmin", "SUPERADMIN" },
                    { "bfea6005-6e38-48a8-958e-ea6625ef0d7a", "8a5bea3a-34ee-48f8-923e-9c4e79837e45", "Admin", "ADMIN" },
                    { "1eedc8f8-cf9d-47ef-8b90-4c5cdd9a0e62", "9a3a1cac-0edd-476f-93ba-c8ec96109c0f", "Gestor", "GESTOR" },
                    { "9bcea184-f1cb-4d4f-9c77-1abacc708999", "a8f229eb-7819-4899-804d-4d26846bea48", "Portero", "PORTERO" }
                });
        }
    }
}
