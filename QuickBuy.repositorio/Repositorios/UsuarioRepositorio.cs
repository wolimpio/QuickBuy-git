using QuickBuy.repositorio.Contexto;
using QuyckBuy.Dominio.contrato;
using QuyckBuy.Dominio.Entidades;
using System.Linq;

namespace QuickBuy.repositorio.Repositorios
{
	public class UsuarioRepositorio : BaseRepositorio<Usuario>, IUsuarioRepositorio
	{
		public UsuarioRepositorio(QuickBuycontexto quickbuycontexto) : base(quickbuycontexto)
		{
		}

		public Usuario Obter(string email, string senha)
		{
			return this.Quickbuycontexto.Usuarios.FirstOrDefault(u => u.Email == email && u.Senha == senha);
		}

		public Usuario Obter(string email)
		{
			return Quickbuycontexto.Usuarios.FirstOrDefault(u => u.Email == email);
		}
	}
}
