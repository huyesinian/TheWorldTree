using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheWorldTree.Migrations
{
    public partial class V7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreeAccessT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreeAccessT",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Creater = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    UpdateOne = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserIP = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeAccessT", x => x.ID);
                });
        }
    }
}
