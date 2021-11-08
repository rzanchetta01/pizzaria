using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaria.Migrations
{
    public partial class initall : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Bebidas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome_bebida = table.Column<string>(type: "varchar(150)", unicode: false, maxLength: 150, nullable: false),
                    descricao_bebida = table.Column<string>(type: "varchar(300)", unicode: false, maxLength: 300, nullable: false),
                    tamanho_bebida = table.Column<int>(type: "int", nullable: false),
                    preco_bebida = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bebidas", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bebidas");
        }
    }
}
