using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace lab_vinfinita.Models
{
    public partial class ProjetoContext : DbContext
    {
        public ProjetoContext()
        {
        }

        public ProjetoContext(DbContextOptions<ProjetoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Comentar> Comentar { get; set; }
        public virtual DbSet<Garrafeira> Garrafeira { get; set; }
        public virtual DbSet<Gerir> Gerir { get; set; }
        public virtual DbSet<Inserir> Inserir { get; set; }
        public virtual DbSet<Possuir> Possuir { get; set; }
        public virtual DbSet<Produtor> Produtor { get; set; }
        public virtual DbSet<Regiao> Regiao { get; set; }
        public virtual DbSet<Sugerir> Sugerir { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Utilizador> Utilizador { get; set; }
        public virtual DbSet<Vinho> Vinho { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=Projeto;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador);

                entity.Property(e => e.IdAdministrador)
                    .HasColumnName("ID_Administrador")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdAdministradorNavigation)
                    .WithOne(p => p.Administrador)
                    .HasForeignKey<Administrador>(d => d.IdAdministrador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Administr__ID_Ad__25869641");
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.Property(e => e.IdCliente)
                    .HasColumnName("ID_Cliente")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cliente__ID_Clie__286302EC");
            });

            modelBuilder.Entity<Comentar>(entity =>
            {
                entity.HasKey(e => new { e.IdCliente, e.IdVinho });

                entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");

                entity.Property(e => e.IdVinho).HasColumnName("ID_Vinho");

                entity.Property(e => e.DataComentario)
                    .HasColumnName("Data_Comentario")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.TextoOpiniao)
                    .IsRequired()
                    .HasColumnName("Texto_Opiniao")
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Comentar)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comentar__ID_Cli__33D4B598");

                entity.HasOne(d => d.IdVinhoNavigation)
                    .WithMany(p => p.Comentar)
                    .HasForeignKey(d => d.IdVinho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comentar__ID_Vin__34C8D9D1");
            });

            modelBuilder.Entity<Garrafeira>(entity =>
            {
                entity.HasKey(e => e.IdGarrafeira);

                entity.Property(e => e.IdGarrafeira)
                    .HasColumnName("ID_Garrafeira")
                    .ValueGeneratedNever();

                entity.Property(e => e.EnderecoCodigo)
                    .IsRequired()
                    .HasColumnName("Endereco_Codigo")
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoLocalidade)
                    .IsRequired()
                    .HasColumnName("Endereco_Localidade")
                    .IsUnicode(false);

                entity.Property(e => e.EnderecoMorada)
                    .IsRequired()
                    .HasColumnName("Endereco_Morada")
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGarrafeiraNavigation)
                    .WithOne(p => p.Garrafeira)
                    .HasForeignKey<Garrafeira>(d => d.IdGarrafeira)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Garrafeir__ID_Ga__2B3F6F97");
            });

            modelBuilder.Entity<Gerir>(entity =>
            {
                entity.HasKey(e => e.IdUtilizador);

                entity.Property(e => e.IdUtilizador)
                    .HasColumnName("ID_Utilizador")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataRegisto)
                    .HasColumnName("Data_Registo")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.DataSuspensao)
                    .HasColumnName("Data_Suspensao")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.IdAdministrador).HasColumnName("ID_Administrador");

                entity.Property(e => e.Motivo)
                    .IsRequired()
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAdministradorNavigation)
                    .WithMany(p => p.Gerir)
                    .HasForeignKey(d => d.IdAdministrador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Gerir__ID_Admini__30F848ED");

                entity.HasOne(d => d.IdUtilizadorNavigation)
                    .WithOne(p => p.Gerir)
                    .HasForeignKey<Gerir>(d => d.IdUtilizador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Gerir__ID_Utiliz__300424B4");
            });

            modelBuilder.Entity<Inserir>(entity =>
            {
                entity.HasKey(e => new { e.IdGarrafeira, e.IdVinho });

                entity.Property(e => e.IdGarrafeira).HasColumnName("ID_Garrafeira");

                entity.Property(e => e.IdVinho).HasColumnName("ID_Vinho");

                entity.Property(e => e.DataInsercao)
                    .HasColumnName("Data_Insercao")
                    .HasColumnType("smalldatetime");

                entity.HasOne(d => d.IdGarrafeiraNavigation)
                    .WithMany(p => p.Inserir)
                    .HasForeignKey(d => d.IdGarrafeira)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inserir__ID_Garr__37A5467C");

                entity.HasOne(d => d.IdVinhoNavigation)
                    .WithMany(p => p.Inserir)
                    .HasForeignKey(d => d.IdVinho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Inserir__ID_Vinh__38996AB5");
            });

            modelBuilder.Entity<Possuir>(entity =>
            {
                entity.HasKey(e => e.IdVinho);

                entity.Property(e => e.IdVinho)
                    .HasColumnName("ID_Vinho")
                    .ValueGeneratedNever();

                entity.Property(e => e.IdProdutor).HasColumnName("ID_Produtor");

                entity.Property(e => e.IdRegiao).HasColumnName("ID_Regiao");

                entity.Property(e => e.IdTipo).HasColumnName("ID_Tipo");

                entity.HasOne(d => d.IdProdutorNavigation)
                    .WithMany(p => p.Possuir)
                    .HasForeignKey(d => d.IdProdutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Possuir__ID_Prod__4316F928");

                entity.HasOne(d => d.IdRegiaoNavigation)
                    .WithMany(p => p.Possuir)
                    .HasForeignKey(d => d.IdRegiao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Possuir__ID_Regi__440B1D61");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Possuir)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Possuir__ID_Tipo__4222D4EF");

                entity.HasOne(d => d.IdVinhoNavigation)
                    .WithOne(p => p.Possuir)
                    .HasForeignKey<Possuir>(d => d.IdVinho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Possuir__ID_Vinh__412EB0B6");
            });

            modelBuilder.Entity<Produtor>(entity =>
            {
                entity.HasKey(e => e.IdProdutor);

                entity.Property(e => e.IdProdutor).HasColumnName("ID_Produtor");

                entity.Property(e => e.NomeProdutor)
                    .IsRequired()
                    .HasColumnName("Nome_Produtor")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Regiao>(entity =>
            {
                entity.HasKey(e => e.IdRegiao);

                entity.Property(e => e.IdRegiao).HasColumnName("ID_Regiao");

                entity.Property(e => e.NomeRegiao)
                    .IsRequired()
                    .HasColumnName("Nome_Regiao")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Sugerir>(entity =>
            {
                entity.HasKey(e => new { e.IdClienteEnvia, e.IdClienteRecebe, e.IdVinho });

                entity.Property(e => e.IdClienteEnvia).HasColumnName("ID_Cliente_Envia");

                entity.Property(e => e.IdClienteRecebe).HasColumnName("ID_Cliente_Recebe");

                entity.Property(e => e.IdVinho).HasColumnName("ID_Vinho");

                entity.Property(e => e.DataSugestao)
                    .HasColumnName("Data_Sugestao")
                    .HasColumnType("smalldatetime");

                entity.Property(e => e.EstadoNotificacao).HasColumnName("Estado_Notificacao");

                entity.Property(e => e.TextoSugestao)
                    .IsRequired()
                    .HasColumnName("Texto_Sugestao")
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteEnviaNavigation)
                    .WithMany(p => p.SugerirIdClienteEnviaNavigation)
                    .HasForeignKey(d => d.IdClienteEnvia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sugerir__ID_Clie__46E78A0C");

                entity.HasOne(d => d.IdClienteRecebeNavigation)
                    .WithMany(p => p.SugerirIdClienteRecebeNavigation)
                    .HasForeignKey(d => d.IdClienteRecebe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sugerir__ID_Clie__47DBAE45");

                entity.HasOne(d => d.IdVinhoNavigation)
                    .WithMany(p => p.Sugerir)
                    .HasForeignKey(d => d.IdVinho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Sugerir__ID_Vinh__48CFD27E");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo);

                entity.Property(e => e.IdTipo).HasColumnName("ID_Tipo");

                entity.Property(e => e.NomeTipo)
                    .IsRequired()
                    .HasColumnName("Nome_Tipo")
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.HasKey(e => e.IdUtilizador);

                entity.Property(e => e.IdUtilizador).HasColumnName("ID_Utilizador");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.EstadoConta).HasColumnName("Estado_Conta");

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vinho>(entity =>
            {
                entity.HasKey(e => e.IdVinho);

                entity.Property(e => e.IdVinho).HasColumnName("ID_Vinho");

                entity.Property(e => e.AnoProducao).HasColumnName("Ano_Producao");

                entity.Property(e => e.Castas)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.FotoFrente)
                    .IsRequired()
                    .HasColumnName("Foto_Frente")
                    .IsUnicode(false);

                entity.Property(e => e.FotoRotulo)
                    .IsRequired()
                    .HasColumnName("Foto_Rotulo")
                    .IsUnicode(false);

                entity.Property(e => e.FotoTras)
                    .IsRequired()
                    .HasColumnName("Foto_Tras")
                    .IsUnicode(false);

                entity.Property(e => e.NomeVinho)
                    .IsRequired()
                    .HasColumnName("Nome_Vinho")
                    .IsUnicode(false);

                entity.Property(e => e.TeorAlcoolico).HasColumnName("Teor_Alcoolico");
            });
        }

        internal void Update()
        {
            throw new NotImplementedException();
        }
    }
}
