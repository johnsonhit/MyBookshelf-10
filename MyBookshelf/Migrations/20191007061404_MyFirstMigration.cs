using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyBookshelf.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookName = table.Column<string>(maxLength: 50, nullable: true),
                    AuthorName = table.Column<string>(maxLength: 50, nullable: true),
                    YearPublish = table.Column<int>(nullable: true),
                    BookGenre = table.Column<string>(maxLength: 50, nullable: true),
                    DateAdd = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserName = table.Column<string>(maxLength: 50, nullable: true),
                    IsRead = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
