using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test3.Data.Migrations
{
    /// <inheritdoc />
    public partial class optsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.CreateTable(
                name: "Categorii_de_bilete",
                columns: table => new
                {
                    Categorie_bilet_ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorii_de_bilete", x => x.Categorie_bilet_ID);
                });*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorii_de_bilete");
        }
    }
}
