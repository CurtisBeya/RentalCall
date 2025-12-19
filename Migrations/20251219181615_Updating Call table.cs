using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AudioSummarizer.Migrations
{
    /// <inheritdoc />
    public partial class UpdatingCalltable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionItems_Audios_AudioId",
                table: "ActionItems");

            migrationBuilder.DropTable(
                name: "Audios");

            migrationBuilder.RenameColumn(
                name: "AudioId",
                table: "ActionItems",
                newName: "CallId");

            migrationBuilder.RenameIndex(
                name: "IX_ActionItems_AudioId",
                table: "ActionItems",
                newName: "IX_ActionItems_CallId");

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudioFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ActionItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UpdatedDateTime",
                value: new DateTime(2025, 1, 2, 12, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.InsertData(
                table: "Calls",
                columns: new[] { "Id", "AudioFileName", "AudioFilePath", "Category", "CreatedDateTime", "Summary", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 1L, "Audio 1", "audio file path test 1", "Booking", new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Client wants to make a booking", null },
                    { 2L, "Audio 2", "audio file path test 2", "Refund", new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Client wants refund asap", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItems_Calls_CallId",
                table: "ActionItems",
                column: "CallId",
                principalTable: "Calls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActionItems_Calls_CallId",
                table: "ActionItems");

            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.RenameColumn(
                name: "CallId",
                table: "ActionItems",
                newName: "AudioId");

            migrationBuilder.RenameIndex(
                name: "IX_ActionItems_CallId",
                table: "ActionItems",
                newName: "IX_ActionItems_AudioId");

            migrationBuilder.CreateTable(
                name: "Audios",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audios", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ActionItems",
                keyColumn: "Id",
                keyValue: 3L,
                column: "UpdatedDateTime",
                value: null);

            migrationBuilder.InsertData(
                table: "Audios",
                columns: new[] { "Id", "AudioFilePath", "CreatedDateTime", "Name", "Summary", "Topic", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 1L, "audio file path test 1", new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Audio 1", "Client wants to make a booking", "Booking", null },
                    { 2L, "audio file path test 2", new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Audio 2", "Client wants refund asap", "Refund", null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_ActionItems_Audios_AudioId",
                table: "ActionItems",
                column: "AudioId",
                principalTable: "Audios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
