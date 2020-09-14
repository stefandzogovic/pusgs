using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Reservations_4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invitesdb_reservationsdb_ReservationId",
                table: "invitesdb");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "reservationsdb",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeatId",
                table: "reservationsdb",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_reservationsdb_SeatId",
                table: "reservationsdb",
                column: "SeatId");

            migrationBuilder.AddForeignKey(
                name: "FK_invitesdb_reservationsdb_ReservationId",
                table: "invitesdb",
                column: "ReservationId",
                principalTable: "reservationsdb",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_reservationsdb_Seat_SeatId",
                table: "reservationsdb",
                column: "SeatId",
                principalTable: "Seat",
                principalColumn: "SeatId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invitesdb_reservationsdb_ReservationId",
                table: "invitesdb");

            migrationBuilder.DropForeignKey(
                name: "FK_reservationsdb_Seat_SeatId",
                table: "reservationsdb");

            migrationBuilder.DropIndex(
                name: "IX_reservationsdb_SeatId",
                table: "reservationsdb");

            migrationBuilder.DropColumn(
                name: "SeatId",
                table: "reservationsdb");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "reservationsdb",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_invitesdb_reservationsdb_ReservationId",
                table: "invitesdb",
                column: "ReservationId",
                principalTable: "reservationsdb",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
