using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZCaixaV5.Migrations
{
    public partial class atualizacao1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Telefone",
                table: "Usuario",
                maxLength: 11,
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 11);

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DataNascimento",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Telefone",
                table: "Usuario",
                type: "int",
                maxLength: 11,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 11,
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuario",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));
        }
    }
}
