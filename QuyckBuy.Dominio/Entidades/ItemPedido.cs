namespace QuyckBuy.Dominio.repositorio
{
	public class ItemPedido : Entidades
	{
		public int Id { get; set; }
		public int ProdutoId { get; set; }
		public int Quantidade { get; set; }
		public int PedidoId { get; set; }
		public virtual Pedido Pedido { get; set; }

		public override void Validate()
		{
			LimparmensagemValidacao();
			if (Quantidade <= 0)
				AdicionarCritica("O produto deve ter quantidade maior que zero.");
		}
	}
}