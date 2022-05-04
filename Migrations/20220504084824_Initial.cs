using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Poke.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PokesM",
                columns: table => new
                {
                    IdP = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PokeN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TypeP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Height = table.Column<double>(type: "float", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    Ability = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PictureP = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    HP = table.Column<double>(type: "float", nullable: false),
                    Atk = table.Column<double>(type: "float", nullable: false),
                    Def = table.Column<double>(type: "float", nullable: false),
                    SpAtk = table.Column<double>(type: "float", nullable: false),
                    SpDef = table.Column<double>(type: "float", nullable: false),
                    Speed = table.Column<double>(type: "float", nullable: false),
                    GenderP = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PokesM", x => x.IdP);
                });

            migrationBuilder.CreateTable(
                name: "TrainersM",
                columns: table => new
                {
                    IdT = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Hometown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(9)", maxLength: 9, nullable: false),
                    Picture = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TrainersM", x => x.IdT);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PokesM");

            migrationBuilder.DropTable(
                name: "TrainersM");
        }
    }
}
