﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace test3.Data.Migrations
{
    /// <inheritdoc />
    public partial class secondsetup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           /* migrationBuilder.CreateTable(
                name: "Artisti",
                columns: table => new
                {
                    ArtistID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prenume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    E_mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NrTelefon = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artisti", x => x.ArtistID);
                });*/
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artisti");
        }
    }
}