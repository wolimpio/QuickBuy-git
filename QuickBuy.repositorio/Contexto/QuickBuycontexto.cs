using Microsoft.EntityFrameworkCore;
using QuickBuy.repositorio.Config;
using QuyckBuy.Dominio.repositorio;

namespace QuickBuy.repositorio.Contexto
{
	public class QuickBuycontexto : DbContext
	{
		public DbSet<Usuario> UsuarioS { get; set; }
		public DbSet<Produto> Produtos { get; set; }
		public DbSet<Pedido> Pedidos { get; set; }
		public DbSet<ItemPedido> ItemPedidos { get; set; }
		
		public DbSet<Formapagamento> Formapagamento { get; set; }

		public QuickBuycontexto(DbContextOptions options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// referencia as classes de mapeamento - Configuracao
			modelBuilder.ApplyConfiguration(new UsuarioConfiguracao());
			modelBuilder.ApplyConfiguration(new ProdutoConfiguracao());
			modelBuilder.ApplyConfiguration(new PedidoConfiguracao());
			modelBuilder.ApplyConfiguration(new ItemPedidoConfiguracao());
			modelBuilder.ApplyConfiguration(new FormaPagamentoConfiguracao());

			// Não remover essa linha
			base.OnModelCreating(modelBuilder);
		}
	}
}
