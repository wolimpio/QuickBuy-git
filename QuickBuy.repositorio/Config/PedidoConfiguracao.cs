using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuyckBuy.Dominio.Entidades;
using System;

namespace QuickBuy.repositorio.Config
{
	public class PedidoConfiguracao : IEntityTypeConfiguration<Pedido>
	{
		public void Configure(EntityTypeBuilder<Pedido> builder)
		{
			builder.HasKey(pedido => pedido.Id);
			builder
				.Property(pedido => pedido.DataPedido)
				.IsRequired();
			builder
				.Property(pedido => pedido.UsuarioId);
			builder
				.Property(pedido => pedido.DataPrevisaoEntrega)
				.IsRequired();
			builder
				.Property(pedido => pedido.CEP)
				.IsRequired()
				.HasMaxLength(9);
			builder
				.Property(pedido => pedido.Estado)
				.IsRequired()
				.HasMaxLength(2);
			builder
				.Property(pedido => pedido.Cidade)
				.IsRequired()
				.HasMaxLength(100);
			builder
				.Property(pedido => pedido.EnderecoCompleto)
				.IsRequired()
				.HasMaxLength(200);
			builder
				.Property(pedido => pedido.NumeroEndereco)
				.IsRequired()
				.HasMaxLength(5);
			builder
				.HasMany(pedido => pedido.ItensPedido)
				.WithOne(itempedido => itempedido.Pedido);

		}
	}
}
