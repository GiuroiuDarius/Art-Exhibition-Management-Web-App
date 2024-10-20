using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test3.Data.Migrations
{
    /// <inheritdoc />
    public partial class fifthsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {/*
            migrationBuilder.CreateTable(
                name: "Bilete",
                columns: table => new
                {
                    BiletID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data_achizitionarii = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Valabilitate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExpozitieID = table.Column<int>(type: "int", nullable: false),
                    VizitatorID = table.Column<int>(type: "int", nullable: false),
                    Categorie_bilet_ID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bilete", x => x.BiletID);
                });*/

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bilete");
        }
    }
}
