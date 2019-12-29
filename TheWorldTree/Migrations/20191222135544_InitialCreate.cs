using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheWorldTree.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreeCatalos",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Creater = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateOne = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    EnglishName = table.Column<string>(maxLength: 50, nullable: true),
                    ParentId = table.Column<string>(maxLength: 50, nullable: false),
                    Url = table.Column<string>(maxLength: 50, nullable: false),
                    Iconic = table.Column<string>(maxLength: 50, nullable: true),
                    Sort = table.Column<int>(nullable: true),
                    Remark = table.Column<string>(maxLength: 200, nullable: true),
                    Enable = table.Column<bool>(nullable: false),
                    IsLast = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeCatalos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TreeFileInfo",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Creater = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateOne = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    ContentID = table.Column<string>(maxLength: 50, nullable: true),
                    FileName = table.Column<string>(maxLength: 100, nullable: true),
                    FileFullName = table.Column<string>(maxLength: 100, nullable: true),
                    FileLength = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    FileSize = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Expanded_name = table.Column<string>(maxLength: 50, nullable: false),
                    Content_Type = table.Column<string>(maxLength: 100, nullable: false),
                    FilePath = table.Column<string>(maxLength: 100, nullable: true),
                    FileRelPath = table.Column<string>(maxLength: 100, nullable: true),
                    Thum_file = table.Column<string>(maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeFileInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TreeFileSuffixType",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Creater = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateOne = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    Expanded_name = table.Column<string>(maxLength: 50, nullable: false),
                    Content_Type = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeFileSuffixType", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TreeIPInfo",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    IPAdd = table.Column<string>(nullable: true),
                    IPAccessTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeIPInfo", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "TreePress",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Creater = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateOne = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Description = table.Column<string>(maxLength: 100, nullable: true),
                    MainBody = table.Column<string>(nullable: false),
                    Issue = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreePress", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreeCatalos");

            migrationBuilder.DropTable(
                name: "TreeFileInfo");

            migrationBuilder.DropTable(
                name: "TreeFileSuffixType");

            migrationBuilder.DropTable(
                name: "TreeIPInfo");

            migrationBuilder.DropTable(
                name: "TreePress");
        }
    }
}
