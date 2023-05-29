using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_vinfinita.Migrations
{
    public partial class Vinhos3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "IdProdutor",
                table: "Vinho",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdRegiao",
                table: "Vinho",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdTipo",
                table: "Vinho",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProdutor",
                table: "Vinho");

            migrationBuilder.DropColumn(
                name: "IdRegiao",
                table: "Vinho");

            migrationBuilder.DropColumn(
                name: "IdTipo",
                table: "Vinho");

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
    }
}
