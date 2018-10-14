using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GeneticsShop.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    name = table.Column<string>(maxLength: 255, nullable: true),
                    price = table.Column<decimal>(type: "decimal(15, 2)", nullable: false, defaultValueSql: "((1.0))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Foxes",
                columns: table => new
                {
                    id_product = table.Column<int>(nullable: false),
                    tails = table.Column<int>(nullable: false, defaultValueSql: "((1))")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Foxes", x => x.id_product);
                    table.ForeignKey(
                        name: "FK_Foxes_Product",
                        column: x => x.id_product,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Katanas",
                columns: table => new
                {
                    id_product = table.Column<int>(nullable: false),
                    sharpness = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Katanas", x => x.id_product);
                    table.ForeignKey(
                        name: "FK_Katanas_Product",
                        column: x => x.id_product,
                        principalTable: "Product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Foxes");

            migrationBuilder.DropTable(
                name: "Katanas");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
