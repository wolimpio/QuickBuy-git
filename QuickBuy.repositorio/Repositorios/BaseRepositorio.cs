using System.Collections.Generic;
using System.Linq;
using QuickBuy.repositorio.Contexto;
using QuyckBuy.Dominio.contrato;

namespace QuickBuy.repositorio.Repositorios
{
	public class BaseRepositorio<TEntity> : IBaserepositorio<TEntity> where TEntity : class
	{
		protected readonly QuickBuycontexto Quickbuycontexto;

		public BaseRepositorio(QuickBuycontexto quickbuycontexto)
		{
			this.Quickbuycontexto = quickbuycontexto;
		}

		public void Adicionar(TEntity entity)
		{
			Quickbuycontexto.Set<TEntity>().Add(entity);
			Quickbuycontexto.SaveChanges();
		}

		public void Atualizar(TEntity entity)
		{
			Quickbuycontexto.Set<TEntity>().Update(entity);
			Quickbuycontexto.SaveChanges();
		}
		
		public TEntity ObterPorId(int id)
		{
			return Quickbuycontexto.Set<TEntity>().Find(id);
		}

		public IEnumerable<TEntity> ObterTodos()
		{
			return Quickbuycontexto.Set<TEntity>().ToList();
		}

		public void Remover(TEntity entity)
		{
			Quickbuycontexto.Remove(entity);
			Quickbuycontexto.SaveChanges();
		}

		public void Dispose()
		{
			Quickbuycontexto.Dispose();
		}

	}
}
