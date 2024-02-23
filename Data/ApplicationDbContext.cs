using Comandas.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Comandas.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ProdutoVendido> ProdutosVendidos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<FormaDePagamento> FormaDePagamento { get; set; }
        public DbSet<MetodoDePagamento> MetodosDePagamento { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Produto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Categoria>()
                .HasMany(c => c.Produtos)
                .WithOne(p => p.Categoria)
                .OnDelete(DeleteBehavior.Cascade);

            //----------------------------------------

            modelBuilder.Entity<ProdutoVendido>()
                .HasOne(p => p.Venda)
                .WithMany(c => c.produtoVendidos)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Venda>()
                .HasMany(c => c.produtoVendidos)
                .WithOne(p => p.Venda)
                .OnDelete(DeleteBehavior.Cascade);

            //----------------------------------------

            modelBuilder.Entity<FormaDePagamento>()
                .HasOne(p => p.Venda)
                .WithMany(c => c.formasDePagamentosDaVenda)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Venda>()
                .HasMany(c => c.formasDePagamentosDaVenda)
                .WithOne(p => p.Venda)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
