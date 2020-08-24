using Microsoft.EntityFrameworkCore.Migrations;

namespace TheWorldTree.Migrations
{
    public partial class V17 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentS",
                table: "TreeSay",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GiveLikeS",
                table: "TreeSay",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CommentS",
                table: "TreeSay");

            migrationBuilder.DropColumn(
                name: "GiveLikeS",
                table: "TreeSay");
        }
    }
}
