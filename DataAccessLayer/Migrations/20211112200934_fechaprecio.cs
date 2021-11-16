using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class fechaprecio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "351c1021-e282-4631-85d3-be96b16b3ccb");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6bc945b9-c7af-453a-9d6d-0f26647cffc7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a2b8e53f-c9b4-454b-b41f-9265bc5a7ee8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ba605798-626e-4c6e-a839-918e48898dc1");

            migrationBuilder.AlterColumn<string>(
                name: "Fecha_Validez",
                table: "Precio",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "8f0b2e07-8a91-432f-850f-7c63cf26facf", "ffb78ed3-99ff-404f-954d-fc8d040ff29c", "SuperAdmin", "SUPERADMIN" },
                    { "e0250b3e-1bb0-489f-bde1-77da6cebd11b", "47a3db23-434c-4e1e-b1ae-5592f7d90e37", "Admin", "ADMIN" },
                    { "cb907407-fc91-4382-9863-8801eb384102", "80df42a2-3504-4379-9224-bb6fd08c9252", "Gestor", "GESTOR" },
                    { "faccf019-a8f8-4a8b-bf90-88a8c0d6b8eb", "ec8ef6cd-b861-4d99-9600-ec407f381fae", "Portero", "PORTERO" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8f0b2e07-8a91-432f-850f-7c63cf26facf");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cb907407-fc91-4382-9863-8801eb384102");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e0250b3e-1bb0-489f-bde1-77da6cebd11b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "faccf019-a8f8-4a8b-bf90-88a8c0d6b8eb");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Fecha_Validez",
                table: "Precio",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "6bc945b9-c7af-453a-9d6d-0f26647cffc7", "eea7c93d-8c5e-47be-a30a-7a2873312bca", "SuperAdmin", "SUPERADMIN" },
                    { "a2b8e53f-c9b4-454b-b41f-9265bc5a7ee8", "08989a56-ddfc-4284-9f11-59283c793077", "Admin", "ADMIN" },
                    { "351c1021-e282-4631-85d3-be96b16b3ccb", "4302323f-cb6c-42f1-bef2-f32cc80a6c57", "Gestor", "GESTOR" },
                    { "ba605798-626e-4c6e-a839-918e48898dc1", "54e04730-0026-4328-81b2-78e72ddda4fb", "Portero", "PORTERO" }
                });
        }
    }
}
