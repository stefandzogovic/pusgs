using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class aviocompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flight_Destination_DestinationId",
                table: "Flight");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destination",
                table: "Destination");

            migrationBuilder.RenameTable(
                name: "Destination",
                newName: "destinationdb");

            migrationBuilder.AddColumn<int>(
                name: "AvioCompanyId",
                table: "destinationdb",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_destinationdb",
                table: "destinationdb",
                column: "DestinationId");

            migrationBuilder.CreateTable(
                name: "aviocompanydb",
                columns: table => new
                {
                    AvioCompanyId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aviocompanydb", x => x.AvioCompanyId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_destinationdb_AvioCompanyId",
                table: "destinationdb",
                column: "AvioCompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_destinationdb_aviocompanydb_AvioCompanyId",
                table: "destinationdb",
                column: "AvioCompanyId",
                principalTable: "aviocompanydb",
                principalColumn: "AvioCompanyId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_destinationdb_DestinationId",
                table: "Flight",
                column: "DestinationId",
                principalTable: "destinationdb",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_destinationdb_aviocompanydb_AvioCompanyId",
                table: "destinationdb");

            migrationBuilder.DropForeignKey(
                name: "FK_Flight_destinationdb_DestinationId",
                table: "Flight");

            migrationBuilder.DropTable(
                name: "aviocompanydb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_destinationdb",
                table: "destinationdb");

            migrationBuilder.DropIndex(
                name: "IX_destinationdb_AvioCompanyId",
                table: "destinationdb");

            migrationBuilder.DropColumn(
                name: "AvioCompanyId",
                table: "destinationdb");

            migrationBuilder.RenameTable(
                name: "destinationdb",
                newName: "Destination");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destination",
                table: "Destination",
                column: "DestinationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Flight_Destination_DestinationId",
                table: "Flight",
                column: "DestinationId",
                principalTable: "Destination",
                principalColumn: "DestinationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
