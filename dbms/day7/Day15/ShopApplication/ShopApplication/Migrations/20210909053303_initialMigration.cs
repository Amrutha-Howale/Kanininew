using Microsoft.EntityFrameworkCore.Migrations;

namespace ShopApplication.Migrations
{
    public partial class initialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "itemsLists",
                columns: table => new
                {
                    ItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductNumber = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ProductPrice = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ItemsListItemId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_itemsLists", x => x.ItemId);
                    table.ForeignKey(
                        name: "FK_itemsLists_itemsLists_ItemsListItemId",
                        column: x => x.ItemsListItemId,
                        principalTable: "itemsLists",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "itemsLists",
                columns: new[] { "ItemId", "ItemsListItemId", "ProductName", "ProductNumber", "ProductPrice", "Quantity" },
                values: new object[] { 101, null, "XXX", 1, 12, 3 });

            migrationBuilder.InsertData(
                table: "itemsLists",
                columns: new[] { "ItemId", "ItemsListItemId", "ProductName", "ProductNumber", "ProductPrice", "Quantity" },
                values: new object[] { 102, null, "YYY", 2, 15, 0 });

            migrationBuilder.InsertData(
                table: "itemsLists",
                columns: new[] { "ItemId", "ItemsListItemId", "ProductName", "ProductNumber", "ProductPrice", "Quantity" },
                values: new object[] { 103, null, "ZZZ", 3, 20, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_itemsLists_ItemsListItemId",
                table: "itemsLists",
                column: "ItemsListItemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "itemsLists");
        }
    }
}
