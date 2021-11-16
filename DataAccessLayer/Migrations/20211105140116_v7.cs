using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class v7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Salones_Edificios_EdificioId",
                table: "Salones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Salones",
                table: "Salones");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "480d8f7d-7e3e-4256-83fc-f2256a7a31fa");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "92f68248-317e-4fd0-8acc-a3f5563688dd");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "95720fbc-d73e-4ad8-8752-b6a8a53ddc51");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d30f67d8-f3f9-4090-9172-046e897e263e");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "480d8f7d-7e3e-4256-83fc-f2256a7a31fa", "e79c2e94-6e99-4796-a37e-2d7200f36d89", "SuperAdmin", "SUPERADMIN" },
                    { "95720fbc-d73e-4ad8-8752-b6a8a53ddc51", "6fe97081-487f-4b01-b3e9-94ded611bfc1", "Admin", "ADMIN" },
                    { "d30f67d8-f3f9-4090-9172-046e897e263e", "4c27fa2e-8339-47a6-a437-1b52dad171ca", "Gestor", "GESTOR" },
                    { "92f68248-317e-4fd0-8acc-a3f5563688dd", "ee599448-f53a-40e0-9359-32e9db56f51f", "Portero", "PORTERO" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Salones_Edificios_EdificioId",
                table: "Salones",
                column: "EdificioId",
                principalTable: "Edificios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
