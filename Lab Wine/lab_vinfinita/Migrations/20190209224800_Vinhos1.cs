using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_vinfinita.Migrations
{
    public partial class Vinhos1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataInsercao",
                table: "Vinho",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Preco",
                table: "Vinho",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Stock",
                table: "Vinho",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataInsercao",
                table: "Vinho");

            migrationBuilder.DropColumn(
                name: "Preco",
                table: "Vinho");

            migrationBuilder.DropColumn(
                name: "Stock",
                table: "Vinho");
        }
    }
}
