using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class v3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Salones",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdificioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoEn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Salones_Edificios_EdificioId",
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
                    { "1a2fa49d-b6b4-4730-926d-be60231e7b74", "fe496b25-1812-4811-8cbf-1e6d8f873444", "SuperAdmin", "SUPERADMIN" },
                    { "94343b70-af12-487a-8366-48ba97499824", "0d3e80b2-0130-4cdc-a5e3-e70dcdad9fc4", "Admin", "ADMIN" },
                    { "2357f7ad-aca4-4cc4-9f2c-ca3f7f917340", "1602845f-55df-4324-a703-9ecb49708879", "Gestor", "GESTOR" },
                    { "f6c4335f-aa19-43cc-81eb-e11a06d82f0a", "cf78450e-3f2b-42b5-92f8-61b19129770b", "Portero", "PORTERO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Salones_EdificioId",
                table: "Salones",
                column: "EdificioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Salones");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1a2fa49d-b6b4-4730-926d-be60231e7b74");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2357f7ad-aca4-4cc4-9f2c-ca3f7f917340");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "94343b70-af12-487a-8366-48ba97499824");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f6c4335f-aa19-43cc-81eb-e11a06d82f0a");

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
    }
}
