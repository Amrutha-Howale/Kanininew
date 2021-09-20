using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StudentApplicationConnectingToDb.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateofJoining = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_students", x => x.Id);
                });
          

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "Id", "DateofJoining", "Name" },
                values: new object[] { 101, new DateTime(2021, 8, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "jack" });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "Id", "DateofJoining", "Name" },
                values: new object[] { 102, new DateTime(2021, 8, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "jill" });

            migrationBuilder.InsertData(
                table: "students",
                columns: new[] { "Id", "DateofJoining", "Name" },
                values: new object[] { 103, new DateTime(2021, 8, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "james" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "students");
        }
    }
}
