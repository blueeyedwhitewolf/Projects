﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using lab_vinfinita.Models;

namespace lab_vinfinita.Migrations
{
    [DbContext(typeof(ProjetoContext))]
    [Migration("20190130204517_Gerir")]
    partial class Gerir
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("lab_vinfinita.Models.Administrador", b =>
                {
                    b.Property<int>("IdAdministrador")
                        .HasColumnName("ID_Administrador");

                    b.HasKey("IdAdministrador");

                    b.ToTable("Administrador");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Cliente", b =>
                {
                    b.Property<int>("IdCliente")
                        .HasColumnName("ID_Cliente");

                    b.HasKey("IdCliente");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Comentar", b =>
                {
                    b.Property<int>("IdCliente")
                        .HasColumnName("ID_Cliente");

                    b.Property<int>("IdVinho")
                        .HasColumnName("ID_Vinho");

                    b.Property<DateTime>("DataComentario")
                        .HasColumnName("Data_Comentario")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("Rating");

                    b.Property<string>("TextoOpiniao")
                        .IsRequired()
                        .HasColumnName("Texto_Opiniao")
                        .IsUnicode(false);

                    b.HasKey("IdCliente", "IdVinho");

                    b.HasIndex("IdVinho");

                    b.ToTable("Comentar");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Garrafeira", b =>
                {
                    b.Property<int>("IdGarrafeira")
                        .HasColumnName("ID_Garrafeira");

                    b.Property<string>("EnderecoCodigo")
                        .IsRequired()
                        .HasColumnName("Endereco_Codigo")
                        .IsUnicode(false);

                    b.Property<string>("EnderecoLocalidade")
                        .IsRequired()
                        .HasColumnName("Endereco_Localidade")
                        .IsUnicode(false);

                    b.Property<string>("EnderecoMorada")
                        .IsRequired()
                        .HasColumnName("Endereco_Morada")
                        .IsUnicode(false);

                    b.HasKey("IdGarrafeira");

                    b.ToTable("Garrafeira");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Gerir", b =>
                {
                    b.Property<int>("IdUtilizador")
                        .HasColumnName("ID_Utilizador");

                    b.Property<DateTime>("DataRegisto")
                        .HasColumnName("Data_Registo")
                        .HasColumnType("smalldatetime");

                    b.Property<DateTime?>("DataSuspensao")
                        .HasColumnName("Data_Suspensao")
                        .HasColumnType("smalldatetime");

                    b.Property<int>("IdAdministrador")
                        .HasColumnName("ID_Administrador");

                    b.Property<string>("Motivo")
                        .IsRequired()
                        .IsUnicode(false);

                    b.HasKey("IdUtilizador");

                    b.HasIndex("IdAdministrador");

                    b.ToTable("Gerir");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Inserir", b =>
                {
                    b.Property<int>("IdGarrafeira")
                        .HasColumnName("ID_Garrafeira");

                    b.Property<int>("IdVinho")
                        .HasColumnName("ID_Vinho");

                    b.Property<DateTime>("DataInsercao")
                        .HasColumnName("Data_Insercao")
                        .HasColumnType("smalldatetime");

                    b.Property<double>("Preco");

                    b.Property<int>("Stock");

                    b.HasKey("IdGarrafeira", "IdVinho");

                    b.HasIndex("IdVinho");

                    b.ToTable("Inserir");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Possuir", b =>
                {
                    b.Property<int>("IdVinho")
                        .HasColumnName("ID_Vinho");

                    b.Property<int>("IdProdutor")
                        .HasColumnName("ID_Produtor");

                    b.Property<int>("IdRegiao")
                        .HasColumnName("ID_Regiao");

                    b.Property<int>("IdTipo")
                        .HasColumnName("ID_Tipo");

                    b.HasKey("IdVinho");

                    b.HasIndex("IdProdutor");

                    b.HasIndex("IdRegiao");

                    b.HasIndex("IdTipo");

                    b.ToTable("Possuir");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Produtor", b =>
                {
                    b.Property<int>("IdProdutor")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Produtor")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeProdutor")
                        .IsRequired()
                        .HasColumnName("Nome_Produtor")
                        .IsUnicode(false);

                    b.HasKey("IdProdutor");

                    b.ToTable("Produtor");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Regiao", b =>
                {
                    b.Property<int>("IdRegiao")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Regiao")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeRegiao")
                        .IsRequired()
                        .HasColumnName("Nome_Regiao")
                        .IsUnicode(false);

                    b.HasKey("IdRegiao");

                    b.ToTable("Regiao");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Sugerir", b =>
                {
                    b.Property<int>("IdClienteEnvia")
                        .HasColumnName("ID_Cliente_Envia");

                    b.Property<int>("IdClienteRecebe")
                        .HasColumnName("ID_Cliente_Recebe");

                    b.Property<int>("IdVinho")
                        .HasColumnName("ID_Vinho");

                    b.Property<DateTime>("DataSugestao")
                        .HasColumnName("Data_Sugestao")
                        .HasColumnType("smalldatetime");

                    b.Property<bool?>("EstadoNotificacao")
                        .HasColumnName("Estado_Notificacao");

                    b.Property<string>("TextoSugestao")
                        .IsRequired()
                        .HasColumnName("Texto_Sugestao")
                        .IsUnicode(false);

                    b.HasKey("IdClienteEnvia", "IdClienteRecebe", "IdVinho");

                    b.HasIndex("IdClienteRecebe");

                    b.HasIndex("IdVinho");

                    b.ToTable("Sugerir");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Tipo", b =>
                {
                    b.Property<int>("IdTipo")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Tipo")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NomeTipo")
                        .IsRequired()
                        .HasColumnName("Nome_Tipo")
                        .IsUnicode(false);

                    b.HasKey("IdTipo");

                    b.ToTable("Tipo");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Utilizador", b =>
                {
                    b.Property<int>("IdUtilizador")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Utilizador")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<int>("EstadoConta")
                        .HasColumnName("Estado_Conta");

                    b.Property<string>("Pass")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("Username")
                        .IsRequired()
                        .IsUnicode(false);

                    b.HasKey("IdUtilizador");

                    b.ToTable("Utilizador");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Vinho", b =>
                {
                    b.Property<int>("IdVinho")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("ID_Vinho")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AnoProducao")
                        .HasColumnName("Ano_Producao");

                    b.Property<double>("Capacidade");

                    b.Property<string>("Castas")
                        .IsRequired()
                        .IsUnicode(false);

                    b.Property<string>("FotoFrente")
                        .IsRequired()
                        .HasColumnName("Foto_Frente")
                        .IsUnicode(false);

                    b.Property<string>("FotoRotulo")
                        .IsRequired()
                        .HasColumnName("Foto_Rotulo")
                        .IsUnicode(false);

                    b.Property<string>("FotoTras")
                        .IsRequired()
                        .HasColumnName("Foto_Tras")
                        .IsUnicode(false);

                    b.Property<string>("NomeVinho")
                        .IsRequired()
                        .HasColumnName("Nome_Vinho")
                        .IsUnicode(false);

                    b.Property<double>("TeorAlcoolico")
                        .HasColumnName("Teor_Alcoolico");

                    b.HasKey("IdVinho");

                    b.ToTable("Vinho");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Administrador", b =>
                {
                    b.HasOne("lab_vinfinita.Models.Utilizador", "IdAdministradorNavigation")
                        .WithOne("Administrador")
                        .HasForeignKey("lab_vinfinita.Models.Administrador", "IdAdministrador")
                        .HasConstraintName("FK__Administr__ID_Ad__25869641");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Cliente", b =>
                {
                    b.HasOne("lab_vinfinita.Models.Utilizador", "IdClienteNavigation")
                        .WithOne("Cliente")
                        .HasForeignKey("lab_vinfinita.Models.Cliente", "IdCliente")
                        .HasConstraintName("FK__Cliente__ID_Clie__286302EC");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Comentar", b =>
                {
                    b.HasOne("lab_vinfinita.Models.Cliente", "IdClienteNavigation")
                        .WithMany("Comentar")
                        .HasForeignKey("IdCliente")
                        .HasConstraintName("FK__Comentar__ID_Cli__33D4B598");

                    b.HasOne("lab_vinfinita.Models.Vinho", "IdVinhoNavigation")
                        .WithMany("Comentar")
                        .HasForeignKey("IdVinho")
                        .HasConstraintName("FK__Comentar__ID_Vin__34C8D9D1");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Garrafeira", b =>
                {
                    b.HasOne("lab_vinfinita.Models.Utilizador", "IdGarrafeiraNavigation")
                        .WithOne("Garrafeira")
                        .HasForeignKey("lab_vinfinita.Models.Garrafeira", "IdGarrafeira")
                        .HasConstraintName("FK__Garrafeir__ID_Ga__2B3F6F97");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Gerir", b =>
                {
                    b.HasOne("lab_vinfinita.Models.Administrador", "IdAdministradorNavigation")
                        .WithMany("Gerir")
                        .HasForeignKey("IdAdministrador")
                        .HasConstraintName("FK__Gerir__ID_Admini__30F848ED");

                    b.HasOne("lab_vinfinita.Models.Utilizador", "IdUtilizadorNavigation")
                        .WithOne("Gerir")
                        .HasForeignKey("lab_vinfinita.Models.Gerir", "IdUtilizador")
                        .HasConstraintName("FK__Gerir__ID_Utiliz__300424B4");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Inserir", b =>
                {
                    b.HasOne("lab_vinfinita.Models.Garrafeira", "IdGarrafeiraNavigation")
                        .WithMany("Inserir")
                        .HasForeignKey("IdGarrafeira")
                        .HasConstraintName("FK__Inserir__ID_Garr__37A5467C");

                    b.HasOne("lab_vinfinita.Models.Vinho", "IdVinhoNavigation")
                        .WithMany("Inserir")
                        .HasForeignKey("IdVinho")
                        .HasConstraintName("FK__Inserir__ID_Vinh__38996AB5");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Possuir", b =>
                {
                    b.HasOne("lab_vinfinita.Models.Produtor", "IdProdutorNavigation")
                        .WithMany("Possuir")
                        .HasForeignKey("IdProdutor")
                        .HasConstraintName("FK__Possuir__ID_Prod__4316F928");

                    b.HasOne("lab_vinfinita.Models.Regiao", "IdRegiaoNavigation")
                        .WithMany("Possuir")
                        .HasForeignKey("IdRegiao")
                        .HasConstraintName("FK__Possuir__ID_Regi__440B1D61");

                    b.HasOne("lab_vinfinita.Models.Tipo", "IdTipoNavigation")
                        .WithMany("Possuir")
                        .HasForeignKey("IdTipo")
                        .HasConstraintName("FK__Possuir__ID_Tipo__4222D4EF");

                    b.HasOne("lab_vinfinita.Models.Vinho", "IdVinhoNavigation")
                        .WithOne("Possuir")
                        .HasForeignKey("lab_vinfinita.Models.Possuir", "IdVinho")
                        .HasConstraintName("FK__Possuir__ID_Vinh__412EB0B6");
                });

            modelBuilder.Entity("lab_vinfinita.Models.Sugerir", b =>
                {
                    b.HasOne("lab_vinfinita.Models.Cliente", "IdClienteEnviaNavigation")
                        .WithMany("SugerirIdClienteEnviaNavigation")
                        .HasForeignKey("IdClienteEnvia")
                        .HasConstraintName("FK__Sugerir__ID_Clie__46E78A0C");

                    b.HasOne("lab_vinfinita.Models.Cliente", "IdClienteRecebeNavigation")
                        .WithMany("SugerirIdClienteRecebeNavigation")
                        .HasForeignKey("IdClienteRecebe")
                        .HasConstraintName("FK__Sugerir__ID_Clie__47DBAE45");

                    b.HasOne("lab_vinfinita.Models.Vinho", "IdVinhoNavigation")
                        .WithMany("Sugerir")
                        .HasForeignKey("IdVinho")
                        .HasConstraintName("FK__Sugerir__ID_Vinh__48CFD27E");
                });
#pragma warning restore 612, 618
        }
    }
}
