using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EventBooking.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRolesAndAdminSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "1", "532cb206-f3d4-4246-b6c9-afe8ffb9731d", "Admin", "ADMIN" },
                    { "2", "046830f8-65c3-4d13-83fa-fa212bda246e", "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "admin-user-id-001", 0, "4dc53cbb-9563-4963-8468-b666ec44afd3", "admin@eventhub.com", true, false, null, "ADMIN@EVENTHUB.COM", "ADMIN@EVENTHUB.COM", "AQAAAAIAAYagAAAAENN2MCI1SFBmlycgOVNwaDpid+EQ15wq+AiO5Xx90ngqrBOEsJ/4BDMw+xrhNORbsQ==", null, false, "STATIC-SECURITY-STAMP-ADMIN", false, "admin@eventhub.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "1", "admin-user-id-001" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "1", "admin-user-id-001" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "admin-user-id-001");
        }
    }
}
