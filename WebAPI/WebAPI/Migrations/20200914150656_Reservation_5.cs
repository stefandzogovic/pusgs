using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class Reservation_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservationsdb_userdb_UserId",
                table: "reservationsdb");

            migrationBuilder.AddForeignKey(
                name: "FK_reservationsdb_userdb_UserId",
                table: "reservationsdb",
                column: "UserId",
                principalTable: "userdb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_reservationsdb_userdb_UserId",
                table: "reservationsdb");

            migrationBuilder.AddForeignKey(
                name: "FK_reservationsdb_userdb_UserId",
                table: "reservationsdb",
                column: "UserId",
                principalTable: "userdb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
