using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class precioOrder : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7a9d92f0-9bb3-4b15-9b36-51cf4065b6af");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bc3eb60d-0c3e-4472-9dff-b0780c6463b1");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "e8b70157-38b3-4ffd-aa9e-622bdc0dbee7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ef4dbcbb-97b7-4bf8-9f60-57483b64b543");

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
                    { "393cdd1d-f84f-42d3-9dca-250f65d095fa", "c33b25cc-097b-4aeb-a286-c2f5d429cf61", "SuperAdmin", "SUPERADMIN" },
                    { "f4184379-711b-4a59-8ff2-9075d3aab038", "bd6b4d32-b038-49ab-b2fb-c00d293d7ec2", "Admin", "ADMIN" },
                    { "8645bd1f-7a53-42ba-a621-5763495ec5c3", "52c73386-2d67-4885-9023-0c874f03bced", "Gestor", "GESTOR" },
                    { "c01bce7a-1437-46fd-9dd0-c4536c92feda", "bb0ad611-9a78-4a54-9239-e2d24681d833", "Portero", "PORTERO" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "393cdd1d-f84f-42d3-9dca-250f65d095fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8645bd1f-7a53-42ba-a621-5763495ec5c3");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c01bce7a-1437-46fd-9dd0-c4536c92feda");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4184379-711b-4a59-8ff2-9075d3aab038");

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
                    { "ef4dbcbb-97b7-4bf8-9f60-57483b64b543", "c2f51c08-3a1a-4ad4-bffb-3f418a2a07bd", "SuperAdmin", "SUPERADMIN" },
                    { "e8b70157-38b3-4ffd-aa9e-622bdc0dbee7", "e761b725-dc19-4874-87b7-cf77030d1267", "Admin", "ADMIN" },
                    { "bc3eb60d-0c3e-4472-9dff-b0780c6463b1", "1e689221-baa9-411d-8f4f-b85a253f6901", "Gestor", "GESTOR" },
                    { "7a9d92f0-9bb3-4b15-9b36-51cf4065b6af", "d3bee3b7-cfdc-41c8-a5a4-973cd425458e", "Portero", "PORTERO" }
                });
        }
    }
}
