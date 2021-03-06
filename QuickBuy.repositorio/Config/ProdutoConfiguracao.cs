﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QuyckBuy.Dominio.Entidades;

namespace QuickBuy.repositorio.Config
{
	public class ProdutoConfiguracao : IEntityTypeConfiguration<Produto>
	{
		public void Configure(EntityTypeBuilder<Produto> builder)
		{
			builder
				.HasKey(produto => produto.Id);

			builder
				.Property(produto => produto.Nome)
				.IsRequired()
				.HasMaxLength(50);
			builder
				.Property(produto => produto.Descricao)
				.IsRequired()
				.HasMaxLength(400);
			builder
				.Property(produto => produto.Preco)
				.IsRequired()
				.HasColumnType("decimal(19,4)");
			builder
				.Property(produto => produto.NomeArquivo)
				.HasMaxLength(255);
		}
	}
}
