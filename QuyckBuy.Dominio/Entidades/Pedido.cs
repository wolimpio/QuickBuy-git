using System;
using System.Collections.Generic;
using System.Linq;

namespace QuyckBuy.Dominio.repositorio
{
	public class Pedido : Entidades
	{
		public int Id { get; set; }
		public DateTime DataPedido { get; set; }
		public int IdUsuario { get; set; }
		public DateTime DataPrevisaoEntrega { get; set; }
		public string CEP { get; set; }
		public string Estado { get; set; }
		public string Cidade { get; set; }
		public string EnderecoCompleto { get; set; }
		public string NumeroEndereço { get; set; }

		public int FormaPagamentoId { get; set; }
		public Formapagamento FormaPagamento { get; set; }

		public ICollection<ItemPedido> ItensPedido { get; set; }

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