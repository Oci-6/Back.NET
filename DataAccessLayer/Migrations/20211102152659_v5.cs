using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class v5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Edificios",
                type: "nvarchar(max)",
                nullable: true);

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Edificios");

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
        }
    }
}
