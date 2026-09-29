using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RentalCall.Migrations
{
    /// <inheritdoc />
    public partial class FirstMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CallCategories",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CallCategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Calls",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AudioFileName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AudioFilePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Summary = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallCategoryId = table.Column<long>(type: "bigint", nullable: false),
                    CallCategoryConfidence = table.Column<double>(type: "float", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Calls", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Calls_CallCategories_CallCategoryId",
                        column: x => x.CallCategoryId,
                        principalTable: "CallCategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ActionItems",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CallId = table.Column<long>(type: "bigint", nullable: false),
                    AssignedToDepartment = table.Column<bool>(type: "bit", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    CompletedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActionItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActionItems_Calls_CallId",
                        column: x => x.CallId,
                        principalTable: "Calls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "CallCategories",
                columns: new[] { "Id", "CreatedDateTime", "Name", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 1L, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Bookings", null },
                    { 2L, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Billings", null },
                    { 3L, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Claims", null },
                    { 4L, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Maintenance", null },
                    { 5L, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Other", null }
                });

            migrationBuilder.InsertData(
                table: "Calls",
                columns: new[] { "Id", "AudioFileName", "AudioFilePath", "CallCategoryConfidence", "CallCategoryId", "CreatedDateTime", "Summary", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 1L, "Audio 1", "audio file path test 1", 0.69999999999999996, 2L, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Client wants to make a booking", null },
                    { 2L, "Audio 2", "audio file path test 2", 0.59999999999999998, 1L, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Client wants refund asap", null },
                    { 3L, "Audio 3", "audio file path test 3", 0.0, 5L, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Client asking for a donation", null }
                });

            migrationBuilder.InsertData(
                table: "ActionItems",
                columns: new[] { "Id", "AssignedToDepartment", "CallId", "CompletedDateTime", "CreatedDateTime", "Description", "IsCompleted", "UpdatedDateTime" },
                values: new object[,]
                {
                    { 1L, true, 1L, null, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Make a reservation", false, null },
                    { 2L, false, 1L, null, new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "Send invoice", false, null },
                    { 3L, true, 2L, new DateTime(2025, 1, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 1, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), "request bank details", true, new DateTime(2025, 1, 2, 12, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActionItems_CallId",
                table: "ActionItems",
                column: "CallId");

            migrationBuilder.CreateIndex(
                name: "IX_Calls_CallCategoryId",
                table: "Calls",
                column: "CallCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActionItems");

            migrationBuilder.DropTable(
                name: "Calls");

            migrationBuilder.DropTable(
                name: "CallCategories");
        }
    }
}
