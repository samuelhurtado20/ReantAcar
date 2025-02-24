using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPi.Migrations
{
    /// <inheritdoc />
    public partial class PassUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                values: new object[] { "57901eec-cb98-435a-97b0-ef4037e2f788", 0, "78777e5e-a7ef-4efe-b004-6b521daafb96", "systemadmin@gmail.com", true, false, null, "systemadmin@gmail.com", "System Administrator", "AQAAAAIAAYagAAAAEAeVqT8mJadg1babxGTyTCOPZ+f9k8mefszvI98TA4VJ5jG7595FF/n3dDV4tnN1fQ==", null, false, "", false, "SystemAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "00000000-0000-0000-0000-000000000001", "57901eec-cb98-435a-97b0-ef4037e2f788" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "00000000-0000-0000-0000-000000000001", "57901eec-cb98-435a-97b0-ef4037e2f788" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "57901eec-cb98-435a-97b0-ef4037e2f788");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "cd0b166d-650b-4562-8955-f3f402b4c8d1", 0, "3f2080f3-0835-4921-b846-0efc75127cb9", "systemadmin@gmail.com", true, false, null, "systemadmin@gmail.com", "System Administrator", "Admin@123", null, false, "", false, "SystemAdmin" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "00000000-0000-0000-0000-000000000001", "cd0b166d-650b-4562-8955-f3f402b4c8d1" });
        }
    }
}
