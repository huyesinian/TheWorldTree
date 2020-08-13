using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheWorldTree.Migrations
{
    public partial class V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreePermission",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Creater = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateOne = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    RoleId = table.Column<string>(nullable: false),
                    ModleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreePermission", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TreeRole",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Creater = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateOne = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    Role = table.Column<string>(nullable: false),
                    Discription = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeRole", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TreeUser",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Creater = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateOne = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    UserName = table.Column<string>(nullable: false),
                    TrueName = table.Column<string>(nullable: false),
                    PassWord = table.Column<string>(nullable: false),
                    Sex = table.Column<string>(nullable: false),
                    Birthday = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: true),
                    Mobile = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeUser", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreePermission");

            migrationBuilder.DropTable(
                name: "TreeRole");

            migrationBuilder.DropTable(
                name: "TreeUser");
        }
    }
}
