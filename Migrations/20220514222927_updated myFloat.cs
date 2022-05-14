using Microsoft.EntityFrameworkCore.Migrations;

namespace Split_IT.Migrations
{
    public partial class updatedmyFloat : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MyFloat",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "Groups",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MyFloat_UserId",
                table: "MyFloat",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_MyFloat_Users_UserId",
                table: "MyFloat",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyFloat_Users_UserId",
                table: "MyFloat");

            migrationBuilder.DropIndex(
                name: "IX_MyFloat_UserId",
                table: "MyFloat");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MyFloat");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "Groups");
        }
    }
}
