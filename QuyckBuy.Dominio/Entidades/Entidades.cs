using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Entidades
{
    public List<string> _mensagemValidacao { get; set; }     
    public List<string> MensagemValidacao 
    {         
        get 
        { 
            return _mensagemValidacao ?? (_mensagemValidacao = new List<string>()); 
        }    
    }
    
    public abstract void Validate();

    protected bool EhValidado 
    {
        get { return !MensagemValidacao.Any(); }
    }
}