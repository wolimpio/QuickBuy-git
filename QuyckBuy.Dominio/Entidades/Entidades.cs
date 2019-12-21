using System;
using System.Collections.Generic;
using System.Linq;

namespace QuyckBuy.Dominio.Entidades
{
	public abstract class Entidades
	{
		private List<string> _mensagemValidacao { get; set; }
		private List<string> MensagemValidacao
		{
			get
			{
				return _mensagemValidacao ?? (_mensagemValidacao = new List<string>());
			}
		}

		public abstract void Validate();

		protected void LimparmensagemValidacao()
		{
			MensagemValidacao.Clear();
		}

		protected void AdicionarCritica(string mensagem)
		{
			MensagemValidacao.Add(mensagem);
		}

		public string ObterMensagemValidacao()
		{
			return string.Join(". ", MensagemValidacao);
		}

		public bool EhValidado
		{
			get { return !MensagemValidacao.Any(); }
		}
	}
}