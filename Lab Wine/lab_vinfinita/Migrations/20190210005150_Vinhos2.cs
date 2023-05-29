using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_vinfinita.Migrations
{
    public partial class Vinhos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NomeProdutor",
                table: "Vinho",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeRegiao",
                table: "Vinho",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeTipo",
                table: "Vinho",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NomeProdutor",
                table: "Vinho");

            migrationBuilder.DropColumn(
                name: "NomeRegiao",
                table: "Vinho");

            migrationBuilder.DropColumn(
                name: "NomeTipo",
                table: "Vinho");
        }
    }
}
