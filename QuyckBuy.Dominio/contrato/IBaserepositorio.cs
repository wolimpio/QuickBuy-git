using System;
using System.Collections.Generic;

namespace QuyckBuy.Dominio.contrato
{
	public interface IBaserepositorio<TEntity> : IDisposable where TEntity: class
	{
		void Adicionar(TEntity entity);
		TEntity ObterPorId(int id);
		IEnumerable<TEntity> ObterTodos();
		void Atualizar(TEntity entity);
		void Remover(TEntity entity);
	}
}
