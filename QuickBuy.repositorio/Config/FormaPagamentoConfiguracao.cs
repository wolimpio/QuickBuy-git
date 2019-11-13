using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace QuickBuy.repositorio.Config
{
	public class FormaPagamentoConfiguracao : IEntityTypeConfiguration<Formapagamento>
	{
		public void Configure(EntityTypeBuilder<Formapagamento> builder)
		{
			builder.HasKey(formaP => formaP.Id);
			builder
				.Property(formaP => formaP.Nome)
				.IsRequired()
				.HasMaxLength(50);
			builder
				.Property(formaP => formaP.Descricao)
				.IsRequired()
				.HasMaxLength(100);
		}
	}
}
