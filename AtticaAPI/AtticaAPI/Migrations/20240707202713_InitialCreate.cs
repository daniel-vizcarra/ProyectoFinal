using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AtticaAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artista",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Biografia = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artista", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ObradeArte",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ArtistaId = table.Column<int>(type: "int", nullable: true),
                    ImagenUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObradeArte", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObradeArte_Artista_ArtistaId",
                        column: x => x.ArtistaId,
                        principalTable: "Artista",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ObradeArte_ArtistaId",
                table: "ObradeArte",
                column: "ArtistaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ObradeArte");

            migrationBuilder.DropTable(
                name: "Artista");
        }
    }
}
