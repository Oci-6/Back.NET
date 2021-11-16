using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class producto2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5c09dcfb-0310-4b44-9f99-760b6404cddc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6693050b-571a-4560-aec6-746647279a96");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d9350d0d-fa89-4fa2-a9d9-b08df3423876");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f4a27196-6afe-40e8-ac1a-30f6bef49b9b");

            migrationBuilder.AddColumn<Guid>(
                name: "ProductoId",
                table: "Precio",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CantMaxEdificios = table.Column<int>(type: "int", nullable: false),
                    CantMaxSalones = table.Column<int>(type: "int", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoEn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Precio_ProductoId",
                table: "Precio",
                column: "ProductoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Precio_Producto_ProductoId",
                table: "Precio",
                column: "ProductoId",
                principalTable: "Producto",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Precio_Producto_ProductoId",
                table: "Precio");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropIndex(
                name: "IX_Precio_ProductoId",
                table: "Precio");

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

            migrationBuilder.DropColumn(
                name: "ProductoId",
                table: "Precio");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "f4a27196-6afe-40e8-ac1a-30f6bef49b9b", "e19b3ca4-5bba-4d90-801e-416a4bb4b5af", "SuperAdmin", "SUPERADMIN" },
                    { "5c09dcfb-0310-4b44-9f99-760b6404cddc", "7f7304ec-6b46-4b60-82d3-4844c18c697b", "Admin", "ADMIN" },
                    { "d9350d0d-fa89-4fa2-a9d9-b08df3423876", "32061480-6b07-4977-973c-60c07f95e602", "Gestor", "GESTOR" },
                    { "6693050b-571a-4560-aec6-746647279a96", "2a4a0fa5-2f56-4f6f-b269-69d4d9b07669", "Portero", "PORTERO" }
                });
        }
    }
}
