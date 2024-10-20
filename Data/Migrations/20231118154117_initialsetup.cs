using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test3.Data.Migrations
{
    /// <inheritdoc />
    public partial class initialsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Expozitie",
                columns: table => new
                {
                    ExpozitieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeExpozitie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TemaExpozitiei = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataInceperii = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataFinalizarii = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expozitie", x => x.ExpozitieID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expozitie");
        }
    }
}
