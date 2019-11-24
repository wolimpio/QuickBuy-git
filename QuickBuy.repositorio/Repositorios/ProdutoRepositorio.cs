using QuickBuy.repositorio.Contexto;
using QuyckBuy.Dominio.contrato;
using QuyckBuy.Dominio.Entidades;

namespace QuickBuy.repositorio.Repositorios
{
	public class ProdutoRepositorio : BaseRepositorio<Produto>, IProdutoRepositorio
	{
		public ProdutoRepositorio(QuickBuycontexto quickbuycontexto) : base(quickbuycontexto)
		{
		}
	}
}
