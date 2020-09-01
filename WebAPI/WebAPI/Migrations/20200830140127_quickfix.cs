using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class quickfix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Friend_userdb_FriendUserId",
                table: "Friend");

            migrationBuilder.DropForeignKey(
                name: "FK_Friend_userdb_MainUserId",
                table: "Friend");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Friend",
                table: "Friend");

            migrationBuilder.RenameTable(
                name: "Friend",
                newName: "frienddb");

            migrationBuilder.RenameIndex(
                name: "IX_Friend_FriendUserId",
                table: "frienddb",
                newName: "IX_frienddb_FriendUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_frienddb",
                table: "frienddb",
                columns: new[] { "MainUserId", "FriendUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_frienddb_userdb_FriendUserId",
                table: "frienddb",
                column: "FriendUserId",
                principalTable: "userdb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_frienddb_userdb_MainUserId",
                table: "frienddb",
                column: "MainUserId",
                principalTable: "userdb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_frienddb_userdb_FriendUserId",
                table: "frienddb");

            migrationBuilder.DropForeignKey(
                name: "FK_frienddb_userdb_MainUserId",
                table: "frienddb");

            migrationBuilder.DropPrimaryKey(
                name: "PK_frienddb",
                table: "frienddb");

            migrationBuilder.RenameTable(
                name: "frienddb",
                newName: "Friend");

            migrationBuilder.RenameIndex(
                name: "IX_frienddb_FriendUserId",
                table: "Friend",
                newName: "IX_Friend_FriendUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Friend",
                table: "Friend",
                columns: new[] { "MainUserId", "FriendUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_userdb_FriendUserId",
                table: "Friend",
                column: "FriendUserId",
                principalTable: "userdb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Friend_userdb_MainUserId",
                table: "Friend",
                column: "MainUserId",
                principalTable: "userdb",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
