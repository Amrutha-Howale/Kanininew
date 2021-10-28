using Microsoft.EntityFrameworkCore.Migrations;

namespace LoginMVC.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DropColumn(
                name: "Email",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "users");

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Password" },
                values: new object[] { 101, "tim" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Password" },
                values: new object[] { 102, "jim" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "Id",
                keyValue: 102);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 1, "tim@gmail.com", "Tim", "tim" });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "Id", "Email", "Name", "Password" },
                values: new object[] { 2, "jim@gmail.com", "Jim", "jim" });
        }
    }
}
