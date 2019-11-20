using System;
using System.Collections.Generic;
using System.Linq;

namespace QuyckBuy.Dominio.repositorio
{
	public class Pedido : Entidades
	{
		public int Id { get; set; }
		public DateTime DataPedido { get; set; }		
		public DateTime DataPrevisaoEntrega { get; set; }
		public string CEP { get; set; }
		public string Estado { get; set; }
		public string Cidade { get; set; }
		public string EnderecoCompleto { get; set; }
		public string NumeroEndereço { get; set; }

		public int FormaPagamentoId { get; set; }
		public virtual Formapagamento FormaPagamento { get; set; }

		/*para fazer a configuração de n/n é necessário ter a propriedade do id da classe pai e outra propriedade com o objeto da classe pai,
		 ambas as propriedades devem começar com o nome da classe (nesse caso iniciam com Usuario) e a propriedade do objeto deve ser declarada 
		 com virtual.
		*/
		public int UsuarioId { get; set; }
		public virtual Usuario Usuario { get; set; }

		public virtual ICollection<ItemPedido> ItensPedido { get; set; }

		public override void Validate()
		{
			LimparmensagemValidacao();
			if (!ItensPedido.Any())
				AdicionarCritica("É necessário adicionar item no pedido.");

			if (string.IsNullOrEmpty(CEP))
				AdicionarCritica("CEP não pode estar em branco.");
		}
	}
}