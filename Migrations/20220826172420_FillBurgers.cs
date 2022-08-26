using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lancheria.Migrations
{
    public partial class FillBurgers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Burgers(CategoryId, DescriptionTiny, DescriptionComplete, Price, ImageUrl, ThumbNailUrl, IsAwesome, Available, BurgerName ) " + "VALUES (1, 'Pão, ovo, presunto, queijo, burger premium, muitoo queijo, alface e tomate', 'Pão Australiano Top, ovo, presunto de primeira, queijo uruguaio, burger com carne top, salada a gosto!', 34.99,'https://exame.com/wp-content/uploads/2020/05/Vinil-Burger.jpg?quality=70&strip=info', 'https://st.depositphotos.com/1557418/2021/v/600/depositphotos_20214545-stock-illustration-hamburger-icon.jpg', 1, 1, 'Bafão')");
            migrationBuilder.Sql("INSERT INTO Burgers(CategoryId, DescriptionTiny, DescriptionComplete, Price, ImageUrl, ThumbNailUrl, IsAwesome, Available, BurgerName ) " + "VALUES (2, 'Grão-de-Bico, Batata-Doce, Beterraba, Soja, Não tem carne, Queijinho-Sintetico, alface e tomate', 'Pão Australiano (Feito em laboratório), Batata-Doce, Beterraba, Soja, Não tem carne, Queijinho-Sintetico, alface e tomate', 34.99,'https://exame.com/wp-content/uploads/2020/05/Vinil-Burger.jpg?quality=70&strip=info', 'https://st.depositphotos.com/1557418/2021/v/600/depositphotos_20214545-stock-illustration-hamburger-icon.jpg', 0, 1, 'TemKTer')");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Burgers");
        }
    }
}
