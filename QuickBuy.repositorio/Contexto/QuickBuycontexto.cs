using Microsoft.EntityFrameworkCore;
using QuickBuy.repositorio.Config;
using QuyckBuy.Dominio.Entidades;

namespace QuickBuy.repositorio.Contexto
{
	public class QuickBuycontexto : DbContext
	{
		public DbSet<Usuario> Usuarios { get; set; }
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

			modelBuilder.Entity<Formapagamento>().HasData(new Formapagamento(1,"Não Definido", "Descrição Não Definido"));
			modelBuilder.Entity<Formapagamento>().HasData(new Formapagamento(2, "Boleto", "Descrição Boleto"));
			modelBuilder.Entity<Formapagamento>().HasData(new Formapagamento(3, "Cartão de Crédito", "Descrição Cartão de Crédito"));
			modelBuilder.Entity<Formapagamento>().HasData(new Formapagamento(4, "Depósito", "Descrição Depósito"));

			// Não remover essa linha
			base.OnModelCreating(modelBuilder);
		}
	}
}
