namespace QuyckBuy.Dominio.Entidades
{
	public class Produto : Entidades
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public decimal Preco { get; set; }
		public string NomeArquivo { get; set; }

		public override void Validate()
		{
			LimparmensagemValidacao();
			if (string.IsNullOrEmpty(Nome))
				AdicionarCritica("O Nome do produto é de preenchimento obrigatório");

			if (string.IsNullOrEmpty(Descricao))
				AdicionarCritica("A descrição do produto é de preenchimento obrigatório");

			if (Preco <= 0)
				AdicionarCritica("O preço do produto deve ser mair que zero.");
		}
	}
}