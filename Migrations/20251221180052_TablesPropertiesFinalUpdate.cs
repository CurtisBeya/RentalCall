using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioSummarizer.Migrations
{
    /// <inheritdoc />
    public partial class TablesPropertiesFinalUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AudioFilePath",
                table: "Calls");

            migrationBuilder.AddColumn<bool>(
                name: "HasActionItemError",
                table: "Calls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HasBeenReviewed",
                table: "Calls",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "ActionItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CallId",
                value: 2L);

            migrationBuilder.UpdateData(
                table: "ActionItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CompletedDateTime",
                value: new DateTime(2025, 1, 3, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 1L,
                columns: new[] { "HasActionItemError", "HasBeenReviewed" },
                values: new object[] { false, false });

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "HasActionItemError", "HasBeenReviewed", "Summary" },
                values: new object[] { false, false, "Client wants their refund processed asap" });

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "HasActionItemError", "HasBeenReviewed", "Summary" },
                values: new object[] { false, false, "unknow person asking for a company donation" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasActionItemError",
                table: "Calls");

            migrationBuilder.DropColumn(
                name: "HasBeenReviewed",
                table: "Calls");

            migrationBuilder.AddColumn<string>(
                name: "AudioFilePath",
                table: "Calls",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "ActionItems",
                keyColumn: "Id",
                keyValue: 2L,
                column: "CallId",
                value: 1L);

            migrationBuilder.UpdateData(
                table: "ActionItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "CompletedDateTime",
                value: new DateTime(2025, 1, 2, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 1L,
                column: "AudioFilePath",
                value: "audio file path test 1");

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 2L,
                columns: new[] { "AudioFilePath", "Summary" },
                values: new object[] { "audio file path test 2", "Client wants refund asap" });

            migrationBuilder.UpdateData(
                table: "Calls",
                keyColumn: "Id",
                keyValue: 3L,
                columns: new[] { "AudioFilePath", "Summary" },
                values: new object[] { "audio file path test 3", "Client asking for a donation" });
        }
    }
}
