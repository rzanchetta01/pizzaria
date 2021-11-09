using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Pizzaria.Migrations
{
    public partial class asnaeb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_avaliacao_pizza",
                table: "AvaliacaosDb");

            migrationBuilder.DropIndex(
                name: "IX_AvaliacaosDb_IdPizza",
                table: "AvaliacaosDb");

            migrationBuilder.RenameColumn(
                name: "IdPizza",
                table: "AvaliacaosDb",
                newName: "id_pizza");

            migrationBuilder.AlterColumn<string>(
                name: "comentarios",
                table: "AvaliacaosDb",
                type: "varchar(400)",
                unicode: false,
                maxLength: 400,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldUnicode: false,
                oldMaxLength: 400);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "id_pizza",
                table: "AvaliacaosDb",
                newName: "IdPizza");

            migrationBuilder.AlterColumn<string>(
                name: "comentarios",
                table: "AvaliacaosDb",
                type: "varchar(400)",
                unicode: false,
                maxLength: 400,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(400)",
                oldUnicode: false,
                oldMaxLength: 400,
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaosDb_IdPizza",
                table: "AvaliacaosDb",
                column: "IdPizza");

            migrationBuilder.AddForeignKey(
                name: "fk_avaliacao_pizza",
                table: "AvaliacaosDb",
                column: "IdPizza",
                principalTable: "Pizzas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
