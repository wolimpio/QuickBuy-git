using QuickBuy.repositorio.Contexto;
using QuyckBuy.Dominio.contrato;
using QuyckBuy.Dominio.Entidades;

namespace QuickBuy.repositorio.Repositorios
{
	public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
	{
		public UsuarioRepositorio(QuickBuycontexto quickbuycontexto) : base(quickbuycontexto)
		{
		}
	}
}
