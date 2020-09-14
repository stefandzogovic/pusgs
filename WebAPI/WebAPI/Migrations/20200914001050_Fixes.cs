using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Fixes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Invite_Reservation_ReservationId",
                table: "Invite");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_flightsdb_FlightId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservation_userdb_UserId",
                table: "Reservation");

            migrationBuilder.DropForeignKey(
                name: "FK_userdb_aviocompanydb_AvioCompanyId",
                table: "userdb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Invite",
                table: "Invite");

            migrationBuilder.RenameTable(
                name: "Reservation",
                newName: "reservationsdb");

            migrationBuilder.RenameTable(
                name: "Invite",
                newName: "invitesdb");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_UserId",
                table: "reservationsdb",
                newName: "IX_reservationsdb_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Reservation_FlightId",
                table: "reservationsdb",
                newName: "IX_reservationsdb_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_Invite_ReservationId",
                table: "invitesdb",
                newName: "IX_invitesdb_ReservationId");

            migrationBuilder.AlterColumn<int>(
                name: "AvioCompanyId",
                table: "userdb",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<bool>(
                name: "Accepted",
                table: "invitesdb",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddPrimaryKey(
                name: "PK_reservationsdb",
                table: "reservationsdb",
                column: "ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_invitesdb",
                table: "invitesdb",
                columns: new[] { "MainUserId", "FriendUserId", "ReservationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_invitesdb_reservationsdb_ReservationId",
                table: "invitesdb",
                column: "ReservationId",
                principalTable: "reservationsdb",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reservationsdb_flightsdb_FlightId",
                table: "reservationsdb",
                column: "FlightId",
                principalTable: "flightsdb",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_reservationsdb_userdb_UserId",
                table: "reservationsdb",
                column: "UserId",
                principalTable: "userdb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userdb_aviocompanydb_AvioCompanyId",
                table: "userdb",
                column: "AvioCompanyId",
                principalTable: "aviocompanydb",
                principalColumn: "AvioCompanyId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_invitesdb_reservationsdb_ReservationId",
                table: "invitesdb");

            migrationBuilder.DropForeignKey(
                name: "FK_reservationsdb_flightsdb_FlightId",
                table: "reservationsdb");

            migrationBuilder.DropForeignKey(
                name: "FK_reservationsdb_userdb_UserId",
                table: "reservationsdb");

            migrationBuilder.DropForeignKey(
                name: "FK_userdb_aviocompanydb_AvioCompanyId",
                table: "userdb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_reservationsdb",
                table: "reservationsdb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_invitesdb",
                table: "invitesdb");

            migrationBuilder.DropColumn(
                name: "Accepted",
                table: "invitesdb");

            migrationBuilder.RenameTable(
                name: "reservationsdb",
                newName: "Reservation");

            migrationBuilder.RenameTable(
                name: "invitesdb",
                newName: "Invite");

            migrationBuilder.RenameIndex(
                name: "IX_reservationsdb_UserId",
                table: "Reservation",
                newName: "IX_Reservation_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_reservationsdb_FlightId",
                table: "Reservation",
                newName: "IX_Reservation_FlightId");

            migrationBuilder.RenameIndex(
                name: "IX_invitesdb_ReservationId",
                table: "Invite",
                newName: "IX_Invite_ReservationId");

            migrationBuilder.AlterColumn<int>(
                name: "AvioCompanyId",
                table: "userdb",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Reservation",
                table: "Reservation",
                column: "ReservationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Invite",
                table: "Invite",
                columns: new[] { "MainUserId", "FriendUserId", "ReservationId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Invite_Reservation_ReservationId",
                table: "Invite",
                column: "ReservationId",
                principalTable: "Reservation",
                principalColumn: "ReservationId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_flightsdb_FlightId",
                table: "Reservation",
                column: "FlightId",
                principalTable: "flightsdb",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservation_userdb_UserId",
                table: "Reservation",
                column: "UserId",
                principalTable: "userdb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_userdb_aviocompanydb_AvioCompanyId",
                table: "userdb",
                column: "AvioCompanyId",
                principalTable: "aviocompanydb",
                principalColumn: "AvioCompanyId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
