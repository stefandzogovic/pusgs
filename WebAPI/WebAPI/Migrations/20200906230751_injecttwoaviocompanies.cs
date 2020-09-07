using Microsoft.EntityFrameworkCore.Migrations;

namespace WebAPI.Migrations
{
    public partial class injecttwoaviocompanies : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvioCompanyId",
                table: "userdb",
                nullable: true);

            migrationBuilder.InsertData(
                table: "aviocompanydb",
                columns: new[] { "AvioCompanyId", "Address", "Description", "Name" },
                values: new object[] { 1, "Adresa Adresa 123A Novi Sad", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. A deserunt neque tempore recusandae animi soluta quasi? Asperiores rem dolore eaque vel, porro, soluta unde debitis aliquam laboriosam. Repellat explicabo, maiores!", "Klisa Airlines" });

            migrationBuilder.InsertData(
                table: "aviocompanydb",
                columns: new[] { "AvioCompanyId", "Address", "Description", "Name" },
                values: new object[] { 2, "Adresa Adresa 123A Novi Sad", "Lorem ipsum dolor sit amet, consectetur adipisicing elit. A deserunt neque tempore recusandae animi soluta quasi? Asperiores rem dolore eaque vel, porro, soluta unde debitis aliquam laboriosam. Repellat explicabo, maiores!", "Slana Bara Airlines" });

            migrationBuilder.CreateIndex(
                name: "IX_userdb_AvioCompanyId",
                table: "userdb",
                column: "AvioCompanyId");

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
                name: "FK_userdb_aviocompanydb_AvioCompanyId",
                table: "userdb");

            migrationBuilder.DropIndex(
                name: "IX_userdb_AvioCompanyId",
                table: "userdb");

            migrationBuilder.DeleteData(
                table: "aviocompanydb",
                keyColumn: "AvioCompanyId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "aviocompanydb",
                keyColumn: "AvioCompanyId",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "AvioCompanyId",
                table: "userdb");
        }
    }
}
