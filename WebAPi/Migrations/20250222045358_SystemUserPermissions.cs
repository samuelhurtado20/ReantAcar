using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebAPi.Migrations
{
    /// <inheritdoc />
    public partial class SystemUserPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000001", "644a5e57-2e94-4710-9a86-c833bed68ff2" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "644a5e57-2e94-4710-9a86-c833bed68ff2");

            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Create_Role", "00000000-0000-0000-0000-000000000001" },
                    { 2, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Read_Role", "00000000-0000-0000-0000-000000000001" },
                    { 3, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Update_Role", "00000000-0000-0000-0000-000000000001" },
                    { 4, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Delete_Role", "00000000-0000-0000-0000-000000000001" },
                    { 5, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Create_User", "00000000-0000-0000-0000-000000000001" },
                    { 6, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Read_User", "00000000-0000-0000-0000-000000000001" },
                    { 7, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Update_User", "00000000-0000-0000-0000-000000000001" },
                    { 8, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Delete_User", "00000000-0000-0000-0000-000000000001" },
                    { 9, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Create_Permission", "00000000-0000-0000-0000-000000000001" },
                    { 10, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Read_Permission", "00000000-0000-0000-0000-000000000001" },
                    { 11, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Update_Permission", "00000000-0000-0000-0000-000000000001" },
                    { 12, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Delete_Permission", "00000000-0000-0000-0000-000000000001" },
                    { 13, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Create_Brand", "00000000-0000-0000-0000-000000000001" },
                    { 14, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Read_Brand", "00000000-0000-0000-0000-000000000001" },
                    { 15, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Update_Brand", "00000000-0000-0000-0000-000000000001" },
                    { 16, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Delete_Brand", "00000000-0000-0000-0000-000000000001" },
                    { 17, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Create_Vehicle", "00000000-0000-0000-0000-000000000001" },
                    { 18, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Read_Vehicle", "00000000-0000-0000-0000-000000000001" },
                    { 19, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Update_Vehicle", "00000000-0000-0000-0000-000000000001" },
                    { 20, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Delete_Vehicle", "00000000-0000-0000-0000-000000000001" },
                    { 21, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Create_Invoice", "00000000-0000-0000-0000-000000000001" },
                    { 22, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Read_Invoice", "00000000-0000-0000-0000-000000000001" },
                    { 23, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Update_Invoice", "00000000-0000-0000-0000-000000000001" },
                    { 24, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Delete_Invoice", "00000000-0000-0000-0000-000000000001" },
                    { 25, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Create_Report", "00000000-0000-0000-0000-000000000001" },
                    { 26, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Read_Report", "00000000-0000-0000-0000-000000000001" },
                    { 27, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Update_Report", "00000000-0000-0000-0000-000000000001" },
                    { 28, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Delete_Report", "00000000-0000-0000-0000-000000000001" },
                    { 29, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Create_Customer", "00000000-0000-0000-0000-000000000001" },
                    { 30, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Read_Customer", "00000000-0000-0000-0000-000000000001" },
                    { 31, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Update_Customer", "00000000-0000-0000-0000-000000000001" },
                    { 32, "http://schemas.microsoft.com/ws/2008/06/identity/claims/role", "Delete_Customer", "00000000-0000-0000-0000-000000000001" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cd0b166d-650b-4562-8955-f3f402b4c8d1", 0, "3f2080f3-0835-4921-b846-0efc75127cb9", "systemadmin@gmail.com", true, false, null, "systemadmin@gmail.com", "System Administrator", "Admin@123", null, false, "", false, "SystemAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "00000000-0000-0000-0000-000000000001", "cd0b166d-650b-4562-8955-f3f402b4c8d1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000001", "cd0b166d-650b-4562-8955-f3f402b4c8d1" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "cd0b166d-650b-4562-8955-f3f402b4c8d1");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "644a5e57-2e94-4710-9a86-c833bed68ff2", 0, "e9aa9a22-2b4c-4c72-91f1-e81d7fa346b5", "systemadmin@gmail.com", true, false, null, "systemadmin@gmail.com", "System Administrator", "Admin@123", null, false, "", false, "SystemAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "00000000-0000-0000-0000-000000000001", "644a5e57-2e94-4710-9a86-c833bed68ff2" });
        }
    }
}
