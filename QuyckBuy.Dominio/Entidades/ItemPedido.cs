namespace QuyckBuy.Dominio.repositorio
{
	public class ItemPedido : Entidades
	{
		public int Id { get; set; }
		public int IdProduto { get; set; }
		public int Quantidade { get; set; }

		public override void Validate()
		{
			LimparmensagemValidacao();
			if (Quantidade <= 0)
				AdicionarCritica("O produto deve ter quantidade maior que zero.");
		}
	}
}