using QuickBuy.repositorio.Contexto;
using QuyckBuy.Dominio.contrato;
using QuyckBuy.Dominio.Entidades;

namespace QuickBuy.repositorio.Repositorios
{
	public class PedidoRepositorio : BaseRepositorio<Pedido>, IPedidoRepositorio
	{
		public PedidoRepositorio(QuickBuycontexto quickbuycontexto) : base(quickbuycontexto)
		{
		}
	}
}
