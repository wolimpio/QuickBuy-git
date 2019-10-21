using System.Collections.Generic;

namespace QuyckBuy.Dominio.Entidades
{
	public class Usuario : Entidades
	{
		public int Id { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public string Nome { get; set; }
		public string Sobrenome { get; set; }

		public ICollection<Pedido> Pedidos { get; set; }

		public override void Validate()
		{
			LimparmensagemValidacao();
			if (string.IsNullOrEmpty(Email))
				AdicionarCritica("O email do usuário deve estar preenchido.");
		}
	}
}