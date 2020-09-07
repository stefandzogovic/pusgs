using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class misc_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_destinationdb_aviocompanydb_AvioCompanyId",
                table: "destinationdb");

            migrationBuilder.AlterColumn<int>(
                name: "AvioCompanyId",
                table: "destinationdb",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_destinationdb_aviocompanydb_AvioCompanyId",
                table: "destinationdb",
                column: "AvioCompanyId",
                principalTable: "aviocompanydb",
                principalColumn: "AvioCompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_destinationdb_aviocompanydb_AvioCompanyId",
                table: "destinationdb");

            migrationBuilder.AlterColumn<int>(
                name: "AvioCompanyId",
                table: "destinationdb",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_destinationdb_aviocompanydb_AvioCompanyId",
                table: "destinationdb",
                column: "AvioCompanyId",
                principalTable: "aviocompanydb",
                principalColumn: "AvioCompanyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
