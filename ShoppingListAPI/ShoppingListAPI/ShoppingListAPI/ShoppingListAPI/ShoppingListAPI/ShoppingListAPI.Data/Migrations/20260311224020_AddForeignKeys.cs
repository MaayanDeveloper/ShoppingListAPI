using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShoppingListAPI.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddForeignKeys : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductIns_ShopLists_ShopListKey",
                table: "ProductIns");

            migrationBuilder.RenameColumn(
                name: "ShopListKey",
                table: "ProductIns",
                newName: "ShopListId");

            migrationBuilder.RenameIndex(
                name: "IX_ProductIns_ShopListKey",
                table: "ProductIns",
                newName: "IX_ProductIns_ShopListId");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UserOs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIns_ShopLists_ShopListId",
                table: "ProductIns",
                column: "ShopListId",
                principalTable: "ShopLists",
                principalColumn: "Key",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductIns_ShopLists_ShopListId",
                table: "ProductIns");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserOs");

            migrationBuilder.RenameColumn(
                name: "ShopListId",
                table: "ProductIns",
                newName: "ShopListKey");

            migrationBuilder.RenameIndex(
                name: "IX_ProductIns_ShopListId",
                table: "ProductIns",
                newName: "IX_ProductIns_ShopListKey");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductIns_ShopLists_ShopListKey",
                table: "ProductIns",
                column: "ShopListKey",
                principalTable: "ShopLists",
                principalColumn: "Key",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
