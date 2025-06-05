using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Dia14 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    PictureUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brand = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantityInStock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProdutoSAV",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idparceiro = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    refx = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    cdbar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    cdbar2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    descr = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nrorig = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    conversao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    nrfabr = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoSAV", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoSAV_idparceiro",
                table: "ProdutoSAV",
                column: "idparceiro");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoSAV_nrfabr",
                table: "ProdutoSAV",
                column: "nrfabr");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoSAV_nrorig",
                table: "ProdutoSAV",
                column: "nrorig");

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoSAV_refx",
                table: "ProdutoSAV",
                column: "refx");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "ProdutoSAV");
        }
    }
}
