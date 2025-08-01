using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistance.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("9d80fcc4-727f-483b-bd81-9ddf36a96992"));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "600345e4-499b-4f28-87d0-dfd5bad66d21", null, "Admin", "ADMIN" },
                    { "c20327b0-ca77-425e-8061-ba3180e374c1", null, "User", "USER" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { new Guid("44c6912e-ad5d-4b29-8ba8-e7ce3f7dfdf5"), "01.08.2025 23:13", "All about technology, gadgets, and innovations.", "Technology", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "600345e4-499b-4f28-87d0-dfd5bad66d21");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c20327b0-ca77-425e-8061-ba3180e374c1");

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CategoryId",
                keyValue: new Guid("44c6912e-ad5d-4b29-8ba8-e7ce3f7dfdf5"));

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "CreatedAt", "Description", "Name", "UpdatedAt" },
                values: new object[] { new Guid("9d80fcc4-727f-483b-bd81-9ddf36a96992"), "01.08.2025 23:10", "All about technology, gadgets, and innovations.", "Technology", null });
        }
    }
}
