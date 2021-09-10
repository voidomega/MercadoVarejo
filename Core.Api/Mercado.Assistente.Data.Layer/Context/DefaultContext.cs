using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Ma.Domain.Entities;
using Mercado.Assistente.Domain.Entities;

namespace MercadoAssistente.Data.Layer.Context
{
    public partial class DefaultContext : DbContext
    {

        public DefaultContext(DbContextOptions options)
            : base(options)
        {
            // ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            //  ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public virtual DbSet<Categorias> Categorias { get; set; }
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<DadosCobrancas> DadosCobrancas { get; set; }
        public virtual DbSet<EnderecoClientes> EnderecoClientes { get; set; }

        public virtual DbSet<Familias> Familias { get; set; }

        public virtual DbSet<Grupos> Grupos { get; set; }
        public virtual DbSet<Funcionarios> Funcionarios { get; set; }
        public virtual DbSet<HistoricoPedidos> HistoricoPedidos { get; set; }
        public virtual DbSet<ImagensProduto> ImagensProduto { get; set; }
        public virtual DbSet<ItemPedidos> ItemPedidos { get; set; }
        public virtual DbSet<Marcas> Marcas { get; set; }
        public virtual DbSet<Pedidos> Pedidos { get; set; }
        public virtual DbSet<Produtos> Produtos { get; set; }
        public virtual DbSet<PromocaoProdutos> PromocaoProdutos { get; set; }
        public virtual DbSet<SituacaoPedidos> SituacaoPedidos { get; set; }
        public virtual DbSet<TipoCobranca> TipoCobranca { get; set; }
        public virtual DbSet<TipoEnderecos> TipoEnderecos { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categorias>(entity =>
            {
                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.Categorias)
                    .HasForeignKey(d => d.IdGrupo)
                    .HasConstraintName("FK_Categoria_Grupo");
            });

            modelBuilder.Entity<Clientes>(entity =>
            {
                entity.HasIndex(e => new { e.CpfCnpj, e.DsEmail, e.DsNmUsuario })
                    .HasName("UNIQUE_Clientes_1")
                    .IsUnique();
            });

            modelBuilder.Entity<DadosCobrancas>(entity =>
            {
                entity.HasKey(e => e.IdDadosCobranca)
                    .HasName("PK_DadosCobranca");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.DadosCobrancas)
                    .HasForeignKey(d => d.IdPedido)
                    .HasConstraintName("Fk_DadosCobrancasPedidos");

                entity.HasOne(d => d.IdTipoCobrancaNavigation)
                    .WithMany(p => p.DadosCobrancas)
                    .HasForeignKey(d => d.IdTipoCobranca)
                    .HasConstraintName("Fk_DadosCobrancasTipoCobranca");
            });

            modelBuilder.Entity<EnderecoClientes>(entity =>
            {
                entity.Property(e => e.IdEnderecoCliente).ValueGeneratedNever();

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.EnderecoClientes)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_EnderecoClientesClientes");

                entity.HasOne(d => d.IdTipoEnderecoNavigation)
                    .WithMany(p => p.EnderecoClientes)
                    .HasForeignKey(d => d.IdTipoEndereco)
                    .HasConstraintName("fk_TipoEndereco");
            });

            modelBuilder.Entity<Familias>(entity =>
            {
                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Familias)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_FamiliasCategorias");
            });

            modelBuilder.Entity<Funcionarios>(entity =>
            {
                entity.HasIndex(e => new { e.CpfFuncionario, e.DsEmail, e.DsNmUsuario })
                    .HasName("UNIQUE_Clientes_2")
                    .IsUnique();
            });

            modelBuilder.Entity<Grupos>(entity =>
            {
                entity.HasKey(e => e.IdGrupo)
                    .HasName("Grupos_pkey");
            });

            modelBuilder.Entity<HistoricoPedidos>(entity =>
            {
                entity.Property(e => e.IdHistoricoPedido).ValueGeneratedNever();

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.HistoricoPedidos)
                    .HasForeignKey(d => d.IdFuncionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_HistoricoPedidosFuncionario");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.HistoricoPedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_StatusPedidosPedidos");
            });

            modelBuilder.Entity<ImagensProduto>(entity =>
            {
                entity.Property(e => e.IdProduto).ValueGeneratedOnAdd();

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.ImagensProduto)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ImagensProdutoProduto");
            });

            modelBuilder.Entity<ItemPedidos>(entity =>
            {
                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.ItemPedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ItemPedidosPedido");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.ItemPedidos)
                    .HasForeignKey(d => d.IdProduto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ItemPedidoProduto");
            });

            modelBuilder.Entity<Pedidos>(entity =>
            {
                entity.Property(e => e.TpFracionado).IsFixedLength();

                entity.HasOne(d => d.IdClienteNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCliente)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_PedidosClientes");

                entity.HasOne(d => d.IdSituacaoPedidoNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdSituacaoPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_PedidosSituacaoPedidos");
            });

            modelBuilder.Entity<Produtos>(entity =>
            {
                entity.HasIndex(e => e.NmProduto)
                    .HasName("UNIQUE_NmProdutos")
                    .IsUnique();

                entity.HasOne(d => d.IdFamiliaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdFamilia)
                    .HasConstraintName("Fk_ProdutosFamilias");

                entity.HasOne(d => d.IdMarcaNavigation)
                    .WithMany(p => p.Produtos)
                    .HasForeignKey(d => d.IdMarca)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("Fk_ProdutosMarcas");
            });

            modelBuilder.Entity<PromocaoProdutos>(entity =>
            {
                entity.Property(e => e.IdPromocaoProdutos).ValueGeneratedNever();

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.PromocaoProdutos)
                    .HasForeignKey(d => d.IdCategoria)
                    .HasConstraintName("Fk_PromocaoProdutosCategorias");

                entity.HasOne(d => d.IdFamiliaNavigation)
                    .WithMany(p => p.PromocaoProdutos)
                    .HasForeignKey(d => d.IdFamilia)
                    .HasConstraintName("Fk_PromocaoProdutosFamilias");

                entity.HasOne(d => d.IdProdutoNavigation)
                    .WithMany(p => p.PromocaoProdutos)
                    .HasForeignKey(d => d.IdProduto)
                    .HasConstraintName("Fk_PromocaoProdutosProdutos");
            });

            modelBuilder.Entity<TipoCobranca>(entity =>
            {
                entity.Property(e => e.FgTipoMoeda).IsFixedLength();
            });

            modelBuilder.Entity<TipoEnderecos>(entity =>
            {
                entity.Property(e => e.IdTipoEndereco).ValueGeneratedNever();
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
