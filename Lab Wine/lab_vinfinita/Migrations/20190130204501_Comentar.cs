using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace lab_vinfinita.Migrations
{
    public partial class Comentar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtor",
                columns: table => new
                {
                    ID_Produtor = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome_Produtor = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtor", x => x.ID_Produtor);
                });

            migrationBuilder.CreateTable(
                name: "Regiao",
                columns: table => new
                {
                    ID_Regiao = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome_Regiao = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regiao", x => x.ID_Regiao);
                });

            migrationBuilder.CreateTable(
                name: "Tipo",
                columns: table => new
                {
                    ID_Tipo = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome_Tipo = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipo", x => x.ID_Tipo);
                });

            migrationBuilder.CreateTable(
                name: "Utilizador",
                columns: table => new
                {
                    ID_Utilizador = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(unicode: false, nullable: false),
                    Username = table.Column<string>(unicode: false, nullable: false),
                    Pass = table.Column<string>(unicode: false, nullable: false),
                    Estado_Conta = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Utilizador", x => x.ID_Utilizador);
                });

            migrationBuilder.CreateTable(
                name: "Vinho",
                columns: table => new
                {
                    ID_Vinho = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome_Vinho = table.Column<string>(unicode: false, nullable: false),
                    Capacidade = table.Column<double>(nullable: false),
                    Foto_Frente = table.Column<string>(unicode: false, nullable: false),
                    Foto_Tras = table.Column<string>(unicode: false, nullable: false),
                    Foto_Rotulo = table.Column<string>(unicode: false, nullable: false),
                    Teor_Alcoolico = table.Column<double>(nullable: false),
                    Castas = table.Column<string>(unicode: false, nullable: false),
                    Ano_Producao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vinho", x => x.ID_Vinho);
                });

            migrationBuilder.CreateTable(
                name: "Administrador",
                columns: table => new
                {
                    ID_Administrador = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrador", x => x.ID_Administrador);
                    table.ForeignKey(
                        name: "FK__Administr__ID_Ad__25869641",
                        column: x => x.ID_Administrador,
                        principalTable: "Utilizador",
                        principalColumn: "ID_Utilizador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    ID_Cliente = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.ID_Cliente);
                    table.ForeignKey(
                        name: "FK__Cliente__ID_Clie__286302EC",
                        column: x => x.ID_Cliente,
                        principalTable: "Utilizador",
                        principalColumn: "ID_Utilizador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Garrafeira",
                columns: table => new
                {
                    ID_Garrafeira = table.Column<int>(nullable: false),
                    Endereco_Codigo = table.Column<string>(unicode: false, nullable: false),
                    Endereco_Morada = table.Column<string>(unicode: false, nullable: false),
                    Endereco_Localidade = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Garrafeira", x => x.ID_Garrafeira);
                    table.ForeignKey(
                        name: "FK__Garrafeir__ID_Ga__2B3F6F97",
                        column: x => x.ID_Garrafeira,
                        principalTable: "Utilizador",
                        principalColumn: "ID_Utilizador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Possuir",
                columns: table => new
                {
                    ID_Vinho = table.Column<int>(nullable: false),
                    ID_Tipo = table.Column<int>(nullable: false),
                    ID_Produtor = table.Column<int>(nullable: false),
                    ID_Regiao = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Possuir", x => x.ID_Vinho);
                    table.ForeignKey(
                        name: "FK__Possuir__ID_Prod__4316F928",
                        column: x => x.ID_Produtor,
                        principalTable: "Produtor",
                        principalColumn: "ID_Produtor",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Possuir__ID_Regi__440B1D61",
                        column: x => x.ID_Regiao,
                        principalTable: "Regiao",
                        principalColumn: "ID_Regiao",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Possuir__ID_Tipo__4222D4EF",
                        column: x => x.ID_Tipo,
                        principalTable: "Tipo",
                        principalColumn: "ID_Tipo",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Possuir__ID_Vinh__412EB0B6",
                        column: x => x.ID_Vinho,
                        principalTable: "Vinho",
                        principalColumn: "ID_Vinho",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Gerir",
                columns: table => new
                {
                    ID_Utilizador = table.Column<int>(nullable: false),
                    ID_Administrador = table.Column<int>(nullable: false),
                    Motivo = table.Column<string>(unicode: false, nullable: false),
                    Data_Registo = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Data_Suspensao = table.Column<DateTime>(type: "smalldatetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gerir", x => x.ID_Utilizador);
                    table.ForeignKey(
                        name: "FK__Gerir__ID_Admini__30F848ED",
                        column: x => x.ID_Administrador,
                        principalTable: "Administrador",
                        principalColumn: "ID_Administrador",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Gerir__ID_Utiliz__300424B4",
                        column: x => x.ID_Utilizador,
                        principalTable: "Utilizador",
                        principalColumn: "ID_Utilizador",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentar",
                columns: table => new
                {
                    ID_Cliente = table.Column<int>(nullable: false),
                    ID_Vinho = table.Column<int>(nullable: false),
                    Rating = table.Column<int>(nullable: false),
                    Texto_Opiniao = table.Column<string>(unicode: false, nullable: false),
                    Data_Comentario = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentar", x => new { x.ID_Cliente, x.ID_Vinho });
                    table.ForeignKey(
                        name: "FK__Comentar__ID_Cli__33D4B598",
                        column: x => x.ID_Cliente,
                        principalTable: "Cliente",
                        principalColumn: "ID_Cliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Comentar__ID_Vin__34C8D9D1",
                        column: x => x.ID_Vinho,
                        principalTable: "Vinho",
                        principalColumn: "ID_Vinho",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Sugerir",
                columns: table => new
                {
                    ID_Cliente_Envia = table.Column<int>(nullable: false),
                    ID_Cliente_Recebe = table.Column<int>(nullable: false),
                    ID_Vinho = table.Column<int>(nullable: false),
                    Estado_Notificacao = table.Column<bool>(nullable: true),
                    Data_Sugestao = table.Column<DateTime>(type: "smalldatetime", nullable: false),
                    Texto_Sugestao = table.Column<string>(unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sugerir", x => new { x.ID_Cliente_Envia, x.ID_Cliente_Recebe, x.ID_Vinho });
                    table.ForeignKey(
                        name: "FK__Sugerir__ID_Clie__46E78A0C",
                        column: x => x.ID_Cliente_Envia,
                        principalTable: "Cliente",
                        principalColumn: "ID_Cliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Sugerir__ID_Clie__47DBAE45",
                        column: x => x.ID_Cliente_Recebe,
                        principalTable: "Cliente",
                        principalColumn: "ID_Cliente",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Sugerir__ID_Vinh__48CFD27E",
                        column: x => x.ID_Vinho,
                        principalTable: "Vinho",
                        principalColumn: "ID_Vinho",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Inserir",
                columns: table => new
                {
                    ID_Garrafeira = table.Column<int>(nullable: false),
                    ID_Vinho = table.Column<int>(nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    Stock = table.Column<int>(nullable: false),
                    Data_Insercao = table.Column<DateTime>(type: "smalldatetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inserir", x => new { x.ID_Garrafeira, x.ID_Vinho });
                    table.ForeignKey(
                        name: "FK__Inserir__ID_Garr__37A5467C",
                        column: x => x.ID_Garrafeira,
                        principalTable: "Garrafeira",
                        principalColumn: "ID_Garrafeira",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__Inserir__ID_Vinh__38996AB5",
                        column: x => x.ID_Vinho,
                        principalTable: "Vinho",
                        principalColumn: "ID_Vinho",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentar_ID_Vinho",
                table: "Comentar",
                column: "ID_Vinho");

            migrationBuilder.CreateIndex(
                name: "IX_Gerir_ID_Administrador",
                table: "Gerir",
                column: "ID_Administrador");

            migrationBuilder.CreateIndex(
                name: "IX_Inserir_ID_Vinho",
                table: "Inserir",
                column: "ID_Vinho");

            migrationBuilder.CreateIndex(
                name: "IX_Possuir_ID_Produtor",
                table: "Possuir",
                column: "ID_Produtor");

            migrationBuilder.CreateIndex(
                name: "IX_Possuir_ID_Regiao",
                table: "Possuir",
                column: "ID_Regiao");

            migrationBuilder.CreateIndex(
                name: "IX_Possuir_ID_Tipo",
                table: "Possuir",
                column: "ID_Tipo");

            migrationBuilder.CreateIndex(
                name: "IX_Sugerir_ID_Cliente_Recebe",
                table: "Sugerir",
                column: "ID_Cliente_Recebe");

            migrationBuilder.CreateIndex(
                name: "IX_Sugerir_ID_Vinho",
                table: "Sugerir",
                column: "ID_Vinho");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentar");

            migrationBuilder.DropTable(
                name: "Gerir");

            migrationBuilder.DropTable(
                name: "Inserir");

            migrationBuilder.DropTable(
                name: "Possuir");

            migrationBuilder.DropTable(
                name: "Sugerir");

            migrationBuilder.DropTable(
                name: "Administrador");

            migrationBuilder.DropTable(
                name: "Garrafeira");

            migrationBuilder.DropTable(
                name: "Produtor");

            migrationBuilder.DropTable(
                name: "Regiao");

            migrationBuilder.DropTable(
                name: "Tipo");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Vinho");

            migrationBuilder.DropTable(
                name: "Utilizador");
        }
    }
}
