using Microsoft.EntityFrameworkCore.Migrations;

namespace Livraria.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Livros",
                columns: table => new
                {
                    FilmeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(maxLength: 128, nullable: false),
                    Autor = table.Column<string>(maxLength: 128, nullable: false),
                    GeneroId = table.Column<int>(nullable: false),
                    Editora = table.Column<string>(maxLength: 128, nullable: false),
                    AnoLancamento = table.Column<int>(fixedLength: true, maxLength: 4, nullable: false),
                    NumeroPaginas = table.Column<int>(nullable: false),
                    Preco = table.Column<decimal>(type: "decimal(6,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livros", x => x.FilmeId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Livros");
        }
    }
}
