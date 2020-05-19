using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheWorldTree.Migrations
{
    public partial class V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "NodeName",
                table: "TreeDic",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NodeCode",
                table: "TreeDic",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DicCode",
                table: "TreeDic",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "TreeAccessT",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Creater = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateOne = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UserIP = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeAccessT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TreeMsgBoard",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Creater = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateOne = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UserIP = table.Column<string>(nullable: true),
                    MsgContent = table.Column<string>(maxLength: 1000, nullable: true),
                    Phone = table.Column<string>(maxLength: 11, nullable: true),
                    Email = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeMsgBoard", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreeAccessT");

            migrationBuilder.DropTable(
                name: "TreeMsgBoard");

            migrationBuilder.AlterColumn<string>(
                name: "NodeName",
                table: "TreeDic",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "NodeCode",
                table: "TreeDic",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "DicCode",
                table: "TreeDic",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
