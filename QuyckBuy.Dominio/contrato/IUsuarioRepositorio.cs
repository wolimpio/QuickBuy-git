using QuyckBuy.Dominio.Entidades;

namespace QuyckBuy.Dominio.contrato
{
	public interface IUsuarioRepositorio : IBaserepositorio<Usuario>
	{
		Usuario Obter(string email, string senha);
	}
}
