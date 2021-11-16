using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class list : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
    }
}
