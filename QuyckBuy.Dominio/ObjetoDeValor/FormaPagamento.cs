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
    public bool EhCartao
    {
        get
        {
            return Id == (int)TipoFormaPagamento.CartaoCredito;
        }
    }
    public bool EhDeposito
    {
        get
        {
            return Id == (int)TipoFormaPagamento.Deposito;
        }
    }
    public bool TipoPagNaoDefinido
    {
        get
        {
            return Id == (int)TipoFormaPagamento.NaoDefinido;
        }
    }
}
