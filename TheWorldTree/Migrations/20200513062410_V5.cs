using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TheWorldTree.Migrations
{
    public partial class V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TreeDic",
                columns: table => new
                {
                    ID = table.Column<string>(maxLength: 50, nullable: false),
                    Creater = table.Column<string>(maxLength: 50, nullable: true),
                    CreateTime = table.Column<DateTime>(nullable: false),
                    UpdateOne = table.Column<string>(nullable: true),
                    UpdateTime = table.Column<DateTime>(nullable: true),
                    DicCode = table.Column<string>(nullable: true),
                    NodeName = table.Column<string>(nullable: true),
                    NodeCode = table.Column<string>(nullable: true),
                    Node1 = table.Column<string>(nullable: true),
                    Node2 = table.Column<string>(nullable: true),
                    Node3 = table.Column<string>(nullable: true),
                    Node4 = table.Column<string>(nullable: true),
                    Node5 = table.Column<string>(nullable: true),
                    Node6 = table.Column<string>(nullable: true),
                    Node7 = table.Column<string>(nullable: true),
                    Node8 = table.Column<string>(nullable: true),
                    Node1Code = table.Column<string>(nullable: true),
                    Node2Code = table.Column<string>(nullable: true),
                    Node3Code = table.Column<string>(nullable: true),
                    Node4Code = table.Column<string>(nullable: true),
                    Node5Code = table.Column<string>(nullable: true),
                    Node6Code = table.Column<string>(nullable: true),
                    Node7Code = table.Column<string>(nullable: true),
                    Node8Code = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TreeDic", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TreeDic");
        }
    }
}
