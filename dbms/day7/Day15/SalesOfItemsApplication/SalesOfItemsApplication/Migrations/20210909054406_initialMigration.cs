using Microsoft.EntityFrameworkCore.Migrations;

namespace SalesOfItemsApplication.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_items", x => x.ItemId);
                });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "ItemId", "ProductName", "ProductPrice", "Quantity" },
                values: new object[] { 101, "XXX", 12, 3 });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "ItemId", "ProductName", "ProductPrice", "Quantity" },
                values: new object[] { 102, "YYY", 15, 0 });

            migrationBuilder.InsertData(
                table: "items",
                columns: new[] { "ItemId", "ProductName", "ProductPrice", "Quantity" },
                values: new object[] { 103, "ZZZ", 20, 2 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "items");
        }
    }
}
