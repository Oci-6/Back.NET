using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class prodid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Precio_Producto_ProductoId",
                table: "Precio");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2902a66b-4230-458c-980e-10819422249c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "452f64de-994a-47b1-96a7-3a59f7ad2f5c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a32ef57f-57cd-410f-9652-4c6e3e537e0d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "de03aa3a-bfd1-4ac6-be9f-b3ed251f2b2b");

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductoId",
                table: "Precio",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Precio_Producto_ProductoId",
                table: "Precio",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Precio_Producto_ProductoId",
                table: "Precio");

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

            migrationBuilder.AlterColumn<Guid>(
                name: "ProductoId",
                table: "Precio",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2902a66b-4230-458c-980e-10819422249c", "2faf4a57-6b84-41ab-98c1-c9dcc8ebfba7", "SuperAdmin", "SUPERADMIN" },
                    { "a32ef57f-57cd-410f-9652-4c6e3e537e0d", "b1f56739-fdac-438d-a12a-643d5d77bcd7", "Admin", "ADMIN" },
                    { "de03aa3a-bfd1-4ac6-be9f-b3ed251f2b2b", "41cd43f0-10eb-4480-956c-814749c0241c", "Gestor", "GESTOR" },
                    { "452f64de-994a-47b1-96a7-3a59f7ad2f5c", "0af68bdd-fc66-4fde-ac99-9b9ccda8679f", "Portero", "PORTERO" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Precio_Producto_ProductoId",
                table: "Precio",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
