using System.Collections.Generic;
using System.Linq;
using QuickBuy.repositorio.Contexto;
using QuyckBuy.Dominio.contrato;

namespace QuickBuy.repositorio.Repositorios
{
	public class BaseRepositorio<TEntity> : IBaserepositorio<TEntity> where TEntity : class
	{
		private readonly QuickBuycontexto _quickbuycontexto;

		public BaseRepositorio(QuickBuycontexto quickbuycontexto)
		{
			this._quickbuycontexto = quickbuycontexto;
		}

		public void Adicionar(TEntity entity)
		{
			_quickbuycontexto.Set<TEntity>().Add(entity);
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
			return _quickbuycontexto.Set<TEntity>().ToList();
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
