using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.MsSql.Migrations
{
    public partial class v1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Announcement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Announcement", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Announcement",
                columns: new[] { "Id", "DateAdded", "Description", "Title" },
                values: new object[] { 1, new DateTime(2021, 11, 14, 16, 42, 23, 799, DateTimeKind.Local).AddTicks(806), "Some announcement 1", "Best Announcement in the World" });

            migrationBuilder.InsertData(
                table: "Announcement",
                columns: new[] { "Id", "DateAdded", "Description", "Title" },
                values: new object[] { 2, new DateTime(2021, 11, 14, 16, 42, 23, 800, DateTimeKind.Local).AddTicks(8022), "Some announcement 2", "Best Announcement in the Universe" });

            migrationBuilder.InsertData(
                table: "Announcement",
                columns: new[] { "Id", "DateAdded", "Description", "Title" },
                values: new object[] { 3, new DateTime(2021, 11, 14, 16, 42, 23, 800, DateTimeKind.Local).AddTicks(8045), "Some announcement 3", "Buy new cheap goods!" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Announcement");
        }
    }
}
