using Microsoft.EntityFrameworkCore;
using SitemaDeComandas.Models;

namespace SitemaDeComandas.Context
{
    public class SistemaComandasContext : DbContext
    {     
        public SistemaComandasContext(DbContextOptions<SistemaComandasContext> options)
            : base(options)
        { }

        public DbSet<Comanda> Comandas { get; set; }
        public DbSet<Cozinha> Cozinhas { get; set; }
        public DbSet<FormaPagamento> FormasPagamentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<ProdutoComanda> ProdutosComandas { get; set; }
        public DbSet<ProdutoVenda> ProdutosVendas { get; set; }
        public DbSet<SituacaoComanda> SituacoesComandas { get; set; }
        public DbSet<SituacaoVenda> SituacoesVendas { get; set; }
        public DbSet<Venda> Vendas { get; set; }
    }
}
