using System;

public class Formapagamento
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public bool EhBoleto
    {
        get
        {
            return Id == (int)TipoFormaPagamento.Boleto;
        }
    }
}
