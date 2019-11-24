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
		// é necessário o virtual para o EF core entender que é n/n e fazer o mapeamento da maneira correta.
		public virtual ICollection<Pedido> Pedidos { get; set; }

		public override void Validate()
		{
			LimparmensagemValidacao();
			if (string.IsNullOrEmpty(Email))
				AdicionarCritica("O email do usuário deve estar preenchido.");
		}
	}
}