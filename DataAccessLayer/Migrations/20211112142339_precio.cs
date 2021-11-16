using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class precio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Precio",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Monto = table.Column<float>(type: "real", nullable: false),
                    Fecha_Validez = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreadoEn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModificadoEn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Precio", x => x.Id);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Precio");

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
        }
    }
}
