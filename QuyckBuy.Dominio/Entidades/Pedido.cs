using System;
using System.Collections.Generic;

public class Pedido
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



    public ICollection<ItemPedido> ItensPedido { get; set; }
}
