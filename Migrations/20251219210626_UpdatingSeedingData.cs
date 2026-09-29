using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RentalCall.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingSeedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActionItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdatedDateTime",
                value: new DateTime(2025, 1, 2, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CallCategoryId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CallCategoryId",
                value: 2L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ActionItems",
                keyColumn: "Id",
                keyValue: 1L,
                column: "UpdatedDateTime",
                value: null);

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 1L,
                column: "CallCategoryId",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CallCategoryId",
                value: 1L);
        }
    }
}
