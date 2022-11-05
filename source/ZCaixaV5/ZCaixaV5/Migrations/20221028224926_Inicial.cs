using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZCaixaV5.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Username = table.Column<string>(nullable: false),
                    Nome = table.Column<string>(maxLength: 150, nullable: false),
                    UltimoNome = table.Column<string>(maxLength: 150, nullable: true),
                    Senha = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Telefone = table.Column<int>(maxLength: 11, nullable: false),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Username);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
