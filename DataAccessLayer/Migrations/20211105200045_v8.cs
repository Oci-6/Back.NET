using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class v8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salon_Edificios_EdificioId",
                table: "Salon");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salon",
                table: "Salon");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "066cd48c-8239-4093-8a46-ee99ff036e31");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "436e837d-57e4-4ea5-bcf0-8ed440dfd7b7");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5a64517f-4bc6-4d2d-9583-e7b9ab9b91c4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "66750881-2e7d-4689-9be0-272c8e7cc2a4");

            migrationBuilder.RenameTable(
                name: "Salon",
                newName: "Salones");

            migrationBuilder.RenameIndex(
                name: "IX_Salon_EdificioId",
                table: "Salones",
                newName: "IX_Salones_EdificioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salones",
                table: "Salones",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Novedades",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Imagen = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EdificioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoEn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Novedades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Novedades_Edificios_EdificioId",
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
                    { "6dcde40b-b834-4e9e-bfa1-f121507db512", "aedb6027-224a-402b-b5ed-2e76f1b1b09d", "SuperAdmin", "SUPERADMIN" },
                    { "dd53a4f8-1f58-4f99-bbfb-d75f6bb80336", "1d39f3a9-aeed-4c01-9d65-5642cb6abd2e", "Admin", "ADMIN" },
                    { "cd66ca2f-bee1-4387-b073-6fcf89a8bf58", "b1614930-9178-4d52-9bab-9b19cb5d9f8a", "Gestor", "GESTOR" },
                    { "cac7e98b-6611-4f74-8fd8-6b16bf132ab4", "ef182701-b3a9-4dda-a922-37fad6913301", "Portero", "PORTERO" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Novedades_EdificioId",
                table: "Novedades",
                column: "EdificioId");

            migrationBuilder.AddForeignKey(
                name: "FK_Salones_Edificios_EdificioId",
                table: "Salones",
                column: "EdificioId",
                principalTable: "Edificios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salones_Edificios_EdificioId",
                table: "Salones");

            migrationBuilder.DropTable(
                name: "Novedades");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salones",
                table: "Salones");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "6dcde40b-b834-4e9e-bfa1-f121507db512");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cac7e98b-6611-4f74-8fd8-6b16bf132ab4");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "cd66ca2f-bee1-4387-b073-6fcf89a8bf58");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd53a4f8-1f58-4f99-bbfb-d75f6bb80336");

            migrationBuilder.RenameTable(
                name: "Salones",
                newName: "Salon");

            migrationBuilder.RenameIndex(
                name: "IX_Salones_EdificioId",
                table: "Salon",
                newName: "IX_Salon_EdificioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Salon",
                table: "Salon",
                column: "Id");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "066cd48c-8239-4093-8a46-ee99ff036e31", "03b89a20-8651-4e3e-92a3-b4c8b2df8cf6", "SuperAdmin", "SUPERADMIN" },
                    { "66750881-2e7d-4689-9be0-272c8e7cc2a4", "4bdefd88-97c9-4a83-aea1-47e8bb80d3be", "Admin", "ADMIN" },
                    { "5a64517f-4bc6-4d2d-9583-e7b9ab9b91c4", "ccde5cb9-8d96-4145-b400-2aa973912f37", "Gestor", "GESTOR" },
                    { "436e837d-57e4-4ea5-bcf0-8ed440dfd7b7", "8a515e62-0fe9-47e5-9849-bdb452bb39d7", "Portero", "PORTERO" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Salon_Edificios_EdificioId",
                table: "Salon",
                column: "EdificioId",
                principalTable: "Edificios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
