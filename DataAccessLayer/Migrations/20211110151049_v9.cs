using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class v9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04222183-49a0-43e5-9fb5-553abcbf3156");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0e3b511e-3e16-48a6-ad69-9a4e146b1052");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "367e8c73-5253-4956-985a-0ec8c5fb95ce");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5fbbff3b-4ad3-4e6e-9c7e-aed9fa6ebdd5");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6216016b-70c8-40a2-ab89-8f6c32e713a5");

            migrationBuilder.CreateTable(
                name: "Accesos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EdificioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    CreadoEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoEn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accesos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Accesos_AspNetUsers_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accesos_Edificios_EdificioId",
                        column: x => x.EdificioId,
                        principalTable: "Edificios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "cdb8a023-d89a-42a5-a4e0-c5c66149b04e", "94c8d232-3336-46ce-b25b-838462b71b21", "SuperAdmin", "SUPERADMIN" },
                    { "84567553-020e-4b23-8005-0c71040cacac", "224a22e6-3986-4789-8839-3916dc2b30c0", "Admin", "ADMIN" },
                    { "32aa01fb-3b7c-46bf-85ba-331d1274c3a0", "f4323770-dd5d-48ef-a8f4-28cf3eb6d446", "Gestor", "GESTOR" },
                    { "7bc29f5e-aed1-45c8-80f8-b2890a170c3d", "7edc3e83-73e2-4d82-b0c8-a7608c904d6b", "Portero", "PORTERO" },
                    { "91f6d0e8-9358-4421-8a26-77a9879cba9b", "34aaf93c-4258-4706-9110-26ddbddb91db", "Persona", "PERSONA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accesos_EdificioId",
                table: "Accesos",
                column: "EdificioId");

            migrationBuilder.CreateIndex(
                name: "IX_Accesos_UsuarioId",
                table: "Accesos",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Accesos");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "32aa01fb-3b7c-46bf-85ba-331d1274c3a0");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7bc29f5e-aed1-45c8-80f8-b2890a170c3d");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "84567553-020e-4b23-8005-0c71040cacac");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "91f6d0e8-9358-4421-8a26-77a9879cba9b");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cdb8a023-d89a-42a5-a4e0-c5c66149b04e");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "367e8c73-5253-4956-985a-0ec8c5fb95ce", "f3b34841-b01b-4c9d-8e39-d03fb3a88bca", "SuperAdmin", "SUPERADMIN" },
                    { "0e3b511e-3e16-48a6-ad69-9a4e146b1052", "b48c010f-0a8f-4d91-a950-678f5d4344fc", "Admin", "ADMIN" },
                    { "5fbbff3b-4ad3-4e6e-9c7e-aed9fa6ebdd5", "3eda2228-f076-4239-a236-25ffc35ee259", "Gestor", "GESTOR" },
                    { "04222183-49a0-43e5-9fb5-553abcbf3156", "8bce91ea-d5f9-4dc4-88d0-c334bc817c95", "Portero", "PORTERO" },
                    { "6216016b-70c8-40a2-ab89-8f6c32e713a5", "84c9f986-25af-46be-bb48-c4fcbe4e7361", "Persona", "PERSONA" }
                });
        }
    }
}
