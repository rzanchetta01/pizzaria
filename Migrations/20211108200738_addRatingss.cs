using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaria.Migrations
{
    public partial class addRatingss : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AvaliacaosDb",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPizza = table.Column<int>(type: "int", nullable: false),
                    rating = table.Column<int>(type: "int", nullable: false),
                    comentarios = table.Column<string>(type: "varchar(400)", unicode: false, maxLength: 400, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AvaliacaosDb", x => x.id);
                    table.ForeignKey(
                        name: "fk_avaliacao_pizza",
                        column: x => x.IdPizza,
                        principalTable: "Pizzas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaosDb_IdPizza",
                table: "AvaliacaosDb",
                column: "IdPizza");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AvaliacaosDb");
        }
    }
}
