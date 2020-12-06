using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SenaiVagas.WebApi.Domains
{
    public partial class SenaiVagasContext : DbContext
    {
        public SenaiVagasContext()
        {
        }

        public SenaiVagasContext(DbContextOptions<SenaiVagasContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Administrador> Administrador { get; set; }
        public virtual DbSet<Candidato> Candidato { get; set; }
        public virtual DbSet<DadoCandidato> DadoCandidato { get; set; }
        public virtual DbSet<DadoEmpresa> DadoEmpresa { get; set; }
        public virtual DbSet<Empresa> Empresa { get; set; }
        public virtual DbSet<Endereco> Endereco { get; set; }
        public virtual DbSet<Formacao> Formacao { get; set; }
        public virtual DbSet<Idioma> Idioma { get; set; }
        public virtual DbSet<Inscricao> Inscricao { get; set; }
        public virtual DbSet<MeusIdiomas> MeusIdiomas { get; set; }
        public virtual DbSet<MinhasFormacoes> MinhasFormacoes { get; set; }
        public virtual DbSet<NivelIdioma> NivelIdioma { get; set; }
        public virtual DbSet<Vaga> Vaga { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-6GS7ET34; Initial Catalog=SenaiVagas; user Id=sa; pwd=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Administrador>(entity =>
            {
                entity.HasKey(e => e.IdAdministrador);

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Administ__A9D105342EE661B6")
                    .IsUnique();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeAdm)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Candidato>(entity =>
            {
                entity.HasKey(e => e.IdCandidato);

                entity.HasIndex(e => e.Cpf)
                    .HasName("UQ__Candidat__C1F897315AC8DB04")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Candidat__A9D105349C147C4B")
                    .IsUnique();

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasColumnName("CPF")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDadoCandidatoNavigation)
                    .WithMany(p => p.Candidato)
                    .HasForeignKey(d => d.IdDadoCandidato)
                    .HasConstraintName("FK__Candidato__IdDad__4BAC3F29");
            });

            modelBuilder.Entity<DadoCandidato>(entity =>
            {
                entity.HasKey(e => e.IdDadoCandidato);

                entity.HasIndex(e => e.Telefone)
                    .HasName("UQ__DadoCand__4EC504B61B65BB6F")
                    .IsUnique();

                entity.Property(e => e.Curriculo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LinkGit)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LinkLinkedin)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LinkPortifolio)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ModeloContratacao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NomeCompleto)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoCarreira)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoTrabalho)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.DadoCandidato)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__DadoCandi__IdEnd__46E78A0C");
            });

            modelBuilder.Entity<DadoEmpresa>(entity =>
            {
                entity.HasKey(e => e.IdDadoEmpresa);

                entity.HasIndex(e => e.NomeEmpresa)
                    .HasName("UQ__DadoEmpr__3C3E55F088A59AEE")
                    .IsUnique();

                entity.HasIndex(e => e.Telefone)
                    .HasName("UQ__DadoEmpr__4EC504B60E22CF4C")
                    .IsUnique();

                entity.Property(e => e.AreaDeAtuacao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Foto)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Fundada)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false);

                entity.Property(e => e.LinkSite)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.NomeEmpresa)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Telefone)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TipoEmpresa)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdEnderecoNavigation)
                    .WithMany(p => p.DadoEmpresa)
                    .HasForeignKey(d => d.IdEndereco)
                    .HasConstraintName("FK__DadoEmpre__IdEnd__3E52440B");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa);

                entity.HasIndex(e => e.Cnpj)
                    .HasName("UQ__Empresa__AA57D6B4AFC971EB")
                    .IsUnique();

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__Empresa__A9D1053493C4ECA4")
                    .IsUnique();

                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("CNPJ")
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDadoEmpresaNavigation)
                    .WithMany(p => p.Empresa)
                    .HasForeignKey(d => d.IdDadoEmpresa)
                    .HasConstraintName("FK__Empresa__IdDadoE__4316F928");
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.IdEndereco);

                entity.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnName("CEP")
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.Cidade)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Rua)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Uf)
                    .IsRequired()
                    .HasColumnName("UF")
                    .HasMaxLength(2)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Formacao>(entity =>
            {
                entity.HasKey(e => e.IdFormacao);

                entity.Property(e => e.Curso)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DataConclusao).HasColumnType("date");

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.Instituicao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Idioma>(entity =>
            {
                entity.HasKey(e => e.IdIdioma);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Inscricao>(entity =>
            {
                entity.HasKey(e => e.IdInscricao);

                entity.Property(e => e.DataInscricao).HasColumnType("date");

                entity.HasOne(d => d.IdCandidatoNavigation)
                    .WithMany(p => p.Inscricao)
                    .HasForeignKey(d => d.IdCandidato)
                    .HasConstraintName("FK__Inscricao__IdCan__5FB337D6");

                entity.HasOne(d => d.IdVagaNavigation)
                    .WithMany(p => p.Inscricao)
                    .HasForeignKey(d => d.IdVaga)
                    .HasConstraintName("FK__Inscricao__IdVag__60A75C0F");
            });

            modelBuilder.Entity<MeusIdiomas>(entity =>
            {
                entity.HasKey(e => e.IdMeusIdiomas);

                entity.HasOne(d => d.IdDadoCandidatoNavigation)
                    .WithMany(p => p.MeusIdiomas)
                    .HasForeignKey(d => d.IdDadoCandidato)
                    .HasConstraintName("FK__MeusIdiom__IdDad__571DF1D5");

                entity.HasOne(d => d.IdIdiomaNavigation)
                    .WithMany(p => p.MeusIdiomas)
                    .HasForeignKey(d => d.IdIdioma)
                    .HasConstraintName("FK__MeusIdiom__IdIdi__5535A963");

                entity.HasOne(d => d.IdNivelIdiomaNavigation)
                    .WithMany(p => p.MeusIdiomas)
                    .HasForeignKey(d => d.IdNivelIdioma)
                    .HasConstraintName("FK__MeusIdiom__IdNiv__5629CD9C");
            });

            modelBuilder.Entity<MinhasFormacoes>(entity =>
            {
                entity.HasKey(e => e.IdMinhasFormacoes);

                entity.HasOne(d => d.IdDadoCandidatoNavigation)
                    .WithMany(p => p.MinhasFormacoes)
                    .HasForeignKey(d => d.IdDadoCandidato)
                    .HasConstraintName("FK__MinhasFor__IdDad__5CD6CB2B");

                entity.HasOne(d => d.IdFormacaoNavigation)
                    .WithMany(p => p.MinhasFormacoes)
                    .HasForeignKey(d => d.IdFormacao)
                    .HasConstraintName("FK__MinhasFor__IdFor__5BE2A6F2");
            });

            modelBuilder.Entity<NivelIdioma>(entity =>
            {
                entity.HasKey(e => e.IdNivelIdioma);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Vaga>(entity =>
            {
                entity.HasKey(e => e.IdVaga);

                entity.Property(e => e.DataInicio).HasColumnType("date");

                entity.Property(e => e.DataTermino).HasColumnType("date");

                entity.Property(e => e.Descricao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LocalTrabalho)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Requisitos)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TipoContratacao)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TituloVaga)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdDadoEmpresaNavigation)
                    .WithMany(p => p.Vaga)
                    .HasForeignKey(d => d.IdDadoEmpresa)
                    .HasConstraintName("FK__Vaga__IdDadoEmpr__4E88ABD4");
            });
        }
    }
}
