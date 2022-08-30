using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lancheria.Migrations
{
    public partial class CheckoutCartItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CheckoutCartItem",
                columns: table => new
                {
                    CheckoutCartItemId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BurgerId = table.Column<int>(type: "int", nullable: true),
                    Ammount = table.Column<int>(type: "int", nullable: false),
                    CheckoutId = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckoutCartItem", x => x.CheckoutCartItemId);
                    table.ForeignKey(
                        name: "FK_CheckoutCartItem_Burgers_BurgerId",
                        column: x => x.BurgerId,
                        principalTable: "Burgers",
                        principalColumn: "BurgerId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_CheckoutCartItem_BurgerId",
                table: "CheckoutCartItem",
                column: "BurgerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CheckoutCartItem");
        }
    }
}
