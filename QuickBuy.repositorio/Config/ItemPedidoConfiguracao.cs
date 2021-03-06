﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuyckBuy.Dominio.Entidades;

namespace QuickBuy.repositorio.Config
{
	public class ItemPedidoConfiguracao : IEntityTypeConfiguration<ItemPedido>
	{
		public void Configure(EntityTypeBuilder<ItemPedido> builder)
		{
			builder.HasKey(item => item.Id);
			builder
				.Property(item => item.PedidoId)
				.IsRequired();
			builder
				.Property(item => item.Quantidade)
				.IsRequired();
		}
	}
}
