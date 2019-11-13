using System.Collections.Generic;
using System.Linq;

namespace QuyckBuy.Dominio.repositorio
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

		protected bool EhValidado
		{
			get { return !MensagemValidacao.Any(); }
		}
	}
}