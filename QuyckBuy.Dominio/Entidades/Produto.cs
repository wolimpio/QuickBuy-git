namespace QuyckBuy.Dominio.repositorio
{
	public class Produto : Entidades
	{
		public int Id { get; set; }
		public string Nome { get; set; }
		public string Descricao { get; set; }
		public decimal Preco { get; set; }

		public override void Validate()
		{
			LimparmensagemValidacao();
			if (Preco <= 0)
				AdicionarCritica("O preço do produto deve ser mair que zero.");
		}
	}
}