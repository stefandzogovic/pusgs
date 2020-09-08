using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class misc_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_destinationdb_DestinationId",
                table: "Flight");

            migrationBuilder.DropForeignKey(
                name: "FK_Stop_Flight_FlightId",
                table: "Stop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Flight",
                table: "Flight");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Stop");

            migrationBuilder.RenameTable(
                name: "Flight",
                newName: "flightsdb");

            migrationBuilder.RenameIndex(
                name: "IX_Flight_DestinationId",
                table: "flightsdb",
                newName: "IX_flightsdb_DestinationId");

            migrationBuilder.AlterColumn<string>(
                name: "Duration",
                table: "flightsdb",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_flightsdb",
                table: "flightsdb",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_flightsdb_destinationdb_DestinationId",
                table: "flightsdb",
                column: "DestinationId",
                principalTable: "destinationdb",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stop_flightsdb_FlightId",
                table: "Stop",
                column: "FlightId",
                principalTable: "flightsdb",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_flightsdb_destinationdb_DestinationId",
                table: "flightsdb");

            migrationBuilder.DropForeignKey(
                name: "FK_Stop_flightsdb_FlightId",
                table: "Stop");

            migrationBuilder.DropPrimaryKey(
                name: "PK_flightsdb",
                table: "flightsdb");

            migrationBuilder.RenameTable(
                name: "flightsdb",
                newName: "Flight");

            migrationBuilder.RenameIndex(
                name: "IX_flightsdb_DestinationId",
                table: "Flight",
                newName: "IX_Flight_DestinationId");

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Stop",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Duration",
                table: "Flight",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Flight",
                table: "Flight",
                column: "FlightId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_destinationdb_DestinationId",
                table: "Flight",
                column: "DestinationId",
                principalTable: "destinationdb",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Stop_Flight_FlightId",
                table: "Stop",
                column: "FlightId",
                principalTable: "Flight",
                principalColumn: "FlightId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
