using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TransactionApp.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "1234", "john" },
                    { 2, "1234", "alice" }
                });

            migrationBuilder.InsertData(
                table: "Transactions",
                columns: new[] { "Id", "Amount", "Date", "Type", "UserId" },
                values: new object[,]
                {
                    { 1, 1000m, new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit", 1 },
                    { 2, 500m, new DateTime(2024, 1, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Debit", 1 },
                    { 3, 2000m, new DateTime(2024, 1, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Credit", 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Transactions",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
