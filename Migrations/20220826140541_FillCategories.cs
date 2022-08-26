using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lancheria.Migrations
{
    public partial class FillCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, CategoryDescription) " + "VALUES ('Com Carne', 'Burgers feitos com as melhores carnes disponíveis nos mercados!')");
            migrationBuilder.Sql("INSERT INTO Categories(CategoryName, CategoryDescription) " + "VALUES ('Veganos', 'Burgers feitos sem as melhores carnes disponíveis nos mercados!')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Categories");
        }
    }
}
