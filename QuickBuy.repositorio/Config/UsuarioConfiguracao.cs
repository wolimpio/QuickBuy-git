using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuyckBuy.Dominio.repositorio;

namespace QuickBuy.repositorio.Config
{
	public class UsuarioConfiguracao : IEntityTypeConfiguration<Usuario>
	{
		public void Configure(EntityTypeBuilder<Usuario> builder)
		{
			builder.HasKey(usuario => usuario.Id);

			// Builder utiliza o padão Fluent
			builder
				.Property(usuario => usuario.Email)
				.IsRequired()
				.HasMaxLength(100);
			builder
				.Property(usuario => usuario.Nome)
				.IsRequired()
				.HasMaxLength(50)
				/*.HasColumnType("varchar")*/;
			builder
				.Property(usuario => usuario.Sobrenome)
				.IsRequired()
				.HasMaxLength(100);
			builder
				.Property(usuario => usuario.Senha)
				.IsRequired()
				.HasMaxLength(400);
			builder
				.HasMany(usuario => usuario.Pedidos) // um usuário tem vários pedidos
				.WithOne(pedido => pedido.Usuario); // o pedido tem apenas um usuário
		}
	}
}
