using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaria.Migrations
{
    public partial class inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Pizzas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_pizza = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    descricao_pizza = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    tamanho_pizza = table.Column<int>(type: "int", nullable: false),
                    preco_pizza = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pizzas", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pizzas");
        }
    }
}
