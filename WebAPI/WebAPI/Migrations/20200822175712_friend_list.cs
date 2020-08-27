using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class friend_list : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "userdb",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_userdb_UserId",
                table: "userdb",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_userdb_userdb_UserId",
                table: "userdb",
                column: "UserId",
                principalTable: "userdb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_userdb_userdb_UserId",
                table: "userdb");

            migrationBuilder.DropIndex(
                name: "IX_userdb_UserId",
                table: "userdb");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "userdb");
        }
    }
}
