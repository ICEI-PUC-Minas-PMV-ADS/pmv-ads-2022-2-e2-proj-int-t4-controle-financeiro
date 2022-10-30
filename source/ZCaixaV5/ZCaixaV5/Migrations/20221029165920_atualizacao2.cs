using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ZCaixaV5.Migrations
{
    public partial class atualizacao2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "Usuario",
                nullable: false,
                oldClrType: typeof(DateTimeOffset),
                oldType: "datetimeoffset");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DataNascimento",
                table: "Usuario",
                type: "datetimeoffset",
                nullable: false,
                oldClrType: typeof(DateTime));
        }
    }
}
