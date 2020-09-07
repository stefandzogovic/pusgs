using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class misc_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userdb_aviocompanydb_AvioCompanyId",
                table: "userdb");

            migrationBuilder.AlterColumn<int>(
                name: "AvioCompanyId",
                table: "userdb",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_userdb_aviocompanydb_AvioCompanyId",
                table: "userdb",
                column: "AvioCompanyId",
                principalTable: "aviocompanydb",
                principalColumn: "AvioCompanyId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userdb_aviocompanydb_AvioCompanyId",
                table: "userdb");

            migrationBuilder.AlterColumn<int>(
                name: "AvioCompanyId",
                table: "userdb",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_userdb_aviocompanydb_AvioCompanyId",
                table: "userdb",
                column: "AvioCompanyId",
                principalTable: "aviocompanydb",
                principalColumn: "AvioCompanyId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
