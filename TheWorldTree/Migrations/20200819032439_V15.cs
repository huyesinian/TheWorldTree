using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheWorldTree.Migrations
{
    public partial class V15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreeSay",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Creater = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateOne = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    SayContent = table.Column<string>(maxLength: 888, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeSay", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreeSay");
        }
    }
}
