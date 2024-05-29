using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedPriorities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Priorities",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("19103700-c018-464f-9c64-4a4bd6924fdf"), "Baja" },
                    { new Guid("3f0ece66-0cb7-49b2-a3c4-8b8a4733964f"), "Alta" },
                    { new Guid("ba44a2e3-bc30-46a0-9285-71180929ada7"), "Media" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: new Guid("19103700-c018-464f-9c64-4a4bd6924fdf"));

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: new Guid("3f0ece66-0cb7-49b2-a3c4-8b8a4733964f"));

            migrationBuilder.DeleteData(
                table: "Priorities",
                keyColumn: "Id",
                keyValue: new Guid("ba44a2e3-bc30-46a0-9285-71180929ada7"));
        }
    }
}
