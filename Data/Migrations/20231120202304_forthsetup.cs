using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test3.Data.Migrations
{
    /// <inheritdoc />
    public partial class forthsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.CreateTable(
                name: "Expozitii",
                columns: table => new
                {
                    ExpozitieID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume_expozitie = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numar_exponate = table.Column<int>(type: "int", nullable: false),
                    Numar_vizitatori = table.Column<int>(type: "int", nullable: false),
                    Tema_expozitiei = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Data_inceperii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Data_incheierii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Locatie = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Expozitii", x => x.ExpozitieID);
                });*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Expozitii");
        }
    }
}
