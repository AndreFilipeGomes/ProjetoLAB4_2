using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ProjetoLAB4_2.Models
{
    public partial class os3mosqueteirosContext : DbContext
    {
        public os3mosqueteirosContext()
        {
        }

        public os3mosqueteirosContext(DbContextOptions<os3mosqueteirosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<AdministrarUtilizador> AdministrarUtilizador { get; set; }
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Comentario> Comentario { get; set; }
        public virtual DbSet<Garrafeira> Garrafeira { get; set; }
        public virtual DbSet<Produtor> Produtor { get; set; }
        public virtual DbSet<Recomendacao> Recomendacao { get; set; }
        public virtual DbSet<Regiao> Regiao { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }
        public virtual DbSet<Utilizador> Utilizador { get; set; }
        public virtual DbSet<Vinho> Vinho { get; set; }
        public virtual DbSet<VinhosDasGarrafeiras> VinhosDasGarrafeiras { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=os3mosqueteiros;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<AdministrarUtilizador>(entity =>
            {
                entity.ToTable("Administrar_Utilizador");

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.DataFim)
                    .HasColumnName("Data_Fim")
                    .HasColumnType("date");

                entity.Property(e => e.DataInicio)
                    .HasColumnName("Data_Inicio")
                    .HasColumnType("date");

                entity.Property(e => e.IdAdministrador).HasColumnName("ID_Administrador");

                entity.Property(e => e.IdUtilizador).HasColumnName("ID_Utilizador");

                entity.Property(e => e.Motivo)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdAdministradorNavigation)
                    .WithMany(p => p.AdministrarUtilizador)
                    .HasForeignKey(d => d.IdAdministrador)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdUtilizadorNavigation)
                    .WithMany(p => p.AdministrarUtilizador)
                    .HasForeignKey(d => d.IdUtilizador)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdUtilizador)
                    .HasName("PK__Cliente__02069817323A3262");

                entity.Property(e => e.IdUtilizador)
                    .HasColumnName("ID_Utilizador")
                    .ValueGeneratedNever();

                entity.HasOne(d => d.IdUtilizadorNavigation)
                    .WithOne(p => p.Cliente)
                    .HasForeignKey<Cliente>(d => d.IdUtilizador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cliente__ID_Util__3C69FB99");
            });

            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasKey(e => new { e.IdCliente, e.IdVinho, e.Data })
                    .HasName("PK__Comentar__268173788F85C487");

                entity.Property(e => e.IdCliente).HasColumnName("ID_Cliente");

                entity.Property(e => e.IdVinho).HasColumnName("ID_Vinho");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.Property(e => e.Texto)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comentari__ID_Cl__440B1D61");

                entity.HasOne(d => d.IdVinhoNavigation)
                    .WithMany(p => p.Comentario)
                    .HasForeignKey(d => d.IdVinho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Comentari__ID_Vi__4316F928");
            });

            modelBuilder.Entity<Garrafeira>(entity =>
            {
                entity.HasKey(e => e.IdUtilizador);

                entity.Property(e => e.IdUtilizador)
                    .HasColumnName("ID_Utilizador")
                    .ValueGeneratedNever();

                entity.Property(e => e.ContactoTelefone).HasColumnName("Contacto_telefone");

                entity.Property(e => e.ContactoTelemovel).HasColumnName("Contacto_telemovel");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Fotografia)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdUtilizadorNavigation)
                    .WithOne(p => p.Garrafeira)
                    .HasForeignKey<Garrafeira>(d => d.IdUtilizador)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Produtor>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Produtor1)
                    .IsRequired()
                    .HasColumnName("Produtor")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Recomendacao>(entity =>
            {
                entity.HasKey(e => new { e.IdEnvio, e.IdRecepcao, e.Data });

                entity.Property(e => e.IdEnvio).HasColumnName("ID_Envio");

                entity.Property(e => e.IdRecepcao).HasColumnName("ID_Recepcao");

                entity.Property(e => e.Data).HasColumnType("date");

                entity.HasOne(d => d.IdEnvioNavigation)
                    .WithMany(p => p.RecomendacaoIdEnvioNavigation)
                    .HasForeignKey(d => d.IdEnvio)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.IdRecepcaoNavigation)
                    .WithMany(p => p.RecomendacaoIdRecepcaoNavigation)
                    .HasForeignKey(d => d.IdRecepcao)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Regiao>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Regiao1)
                    .IsRequired()
                    .HasColumnName("Regiao")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Tipo1)
                    .IsRequired()
                    .HasColumnName("Tipo")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Utilizador>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CodPostal).HasColumnName("Cod_Postal");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdMorada).HasColumnName("ID_Morada");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vinho>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DateInsercao).HasColumnType("smalldatetime");

                entity.Property(e => e.Fotografia)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.IdProdutor).HasColumnName("ID_Produtor");

                entity.Property(e => e.IdRegiao).HasColumnName("ID_Regiao");

                entity.Property(e => e.IdTipo).HasColumnName("ID_Tipo");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TeorAlcool).HasColumnName("Teor_Alcool");

                entity.HasOne(d => d.IdProdutorNavigation)
                    .WithMany(p => p.Vinho)
                    .HasForeignKey(d => d.IdProdutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vinho__ID_Produt__398D8EEE");

                entity.HasOne(d => d.IdRegiaoNavigation)
                    .WithMany(p => p.Vinho)
                    .HasForeignKey(d => d.IdRegiao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vinho__ID_Regiao__37A5467C");

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Vinho)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vinho__ID_Tipo__38996AB5");
            });

            modelBuilder.Entity<VinhosDasGarrafeiras>(entity =>
            {
                entity.HasKey(e => new { e.IdVinho, e.IdGarrafeira })
                    .HasName("PK__Vinhos_d__BEEAA4AE59694726");

                entity.ToTable("Vinhos_das_Garrafeiras");

                entity.Property(e => e.IdVinho).HasColumnName("ID_Vinho");

                entity.Property(e => e.IdGarrafeira).HasColumnName("ID_Garrafeira");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdGarrafeiraNavigation)
                    .WithMany(p => p.VinhosDasGarrafeiras)
                    .HasForeignKey(d => d.IdGarrafeira)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vinhos_da__ID_Ga__403A8C7D");

                entity.HasOne(d => d.IdVinhoNavigation)
                    .WithMany(p => p.VinhosDasGarrafeiras)
                    .HasForeignKey(d => d.IdVinho)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Vinhos_da__ID_Vi__3F466844");
            });
        }
    }
}
