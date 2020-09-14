using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class seats : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservationsdb_Seat_SeatId",
                table: "reservationsdb");

            migrationBuilder.DropIndex(
                name: "IX_reservationsdb_SeatId",
                table: "reservationsdb");

            migrationBuilder.AddColumn<int>(
                name: "ReservationId",
                table: "Seat",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Seat_ReservationId",
                table: "Seat",
                column: "ReservationId",
                unique: true,
                filter: "[ReservationId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_reservationsdb_ReservationId",
                table: "Seat",
                column: "ReservationId",
                principalTable: "reservationsdb",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_reservationsdb_ReservationId",
                table: "Seat");

            migrationBuilder.DropIndex(
                name: "IX_Seat_ReservationId",
                table: "Seat");

            migrationBuilder.DropColumn(
                name: "ReservationId",
                table: "Seat");

            migrationBuilder.CreateIndex(
                name: "IX_reservationsdb_SeatId",
                table: "reservationsdb",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_reservationsdb_Seat_SeatId",
                table: "reservationsdb",
                column: "SeatId",
                principalTable: "Seat",
                principalColumn: "SeatId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
