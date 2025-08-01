using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class CreatingIdentityTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("07b98df6-d352-4880-b450-4d36fe6246b7"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { new Guid("9d80fcc4-727f-483b-bd81-9ddf36a96992"), "01.08.2025 23:10", "All about technology, gadgets, and innovations.", "Technology", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("9d80fcc4-727f-483b-bd81-9ddf36a96992"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { new Guid("07b98df6-d352-4880-b450-4d36fe6246b7"), "26.07.2025 02:56", "All about technology, gadgets, and innovations.", "Technology", null });
        }
    }
}
