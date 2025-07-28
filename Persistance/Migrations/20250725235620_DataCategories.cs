using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class DataCategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { new Guid("07b98df6-d352-4880-b450-4d36fe6246b7"), "26.07.2025 02:56", "All about technology, gadgets, and innovations.", "Technology", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("07b98df6-d352-4880-b450-4d36fe6246b7"));
        }
    }
}
