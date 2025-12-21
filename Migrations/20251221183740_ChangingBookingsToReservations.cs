using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AudioSummarizer.Migrations
{
    /// <inheritdoc />
    public partial class ChangingBookingsToReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CallCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "Reservations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "CallCategories",
                keyColumn: "Id",
                keyValue: 1L,
                column: "Name",
                value: "Bookings");
        }
    }
}
