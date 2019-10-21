using System.Collections.Generic;
using QuyckBuy.Dominio.contrato;

namespace QuickBuy.repositorio.Repositorios
{
	public class BaseRepositorio<TEntity> : IBaserepositorio<TEntity> where TEntity : class
	{
		public void Adicionar(TEntity entity)
		{
			throw new System.NotImplementedException();
		}

		public void Atualizar(TEntity entity)
		{
			throw new System.NotImplementedException();
		}
		
		public TEntity ObterPorId(int id)
		{
			throw new System.NotImplementedException();
		}

		public IEnumerable<TEntity> ObterTodos()
		{
			throw new System.NotImplementedException();
		}

		public void Remover(TEntity entity)
		{
			throw new System.NotImplementedException();
		}

		public void Dispose()
		{
			throw new System.NotImplementedException();
		}

	}
}
