using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class friend_list_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Friend",
                columns: table => new
                {
                    MainUserId = table.Column<int>(nullable: false),
                    FriendUserId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Friend", x => new { x.MainUserId, x.FriendUserId });
                    table.ForeignKey(
                        name: "FK_Friend_userdb_FriendUserId",
                        column: x => x.FriendUserId,
                        principalTable: "userdb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Friend_userdb_MainUserId",
                        column: x => x.MainUserId,
                        principalTable: "userdb",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Friend_FriendUserId",
                table: "Friend",
                column: "FriendUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Friend");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "userdb",
                type: "int",
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
    }
}
