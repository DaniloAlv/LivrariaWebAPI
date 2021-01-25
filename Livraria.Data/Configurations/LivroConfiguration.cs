using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Data.Configurations
{
	public class LivroConfiguration : IEntityTypeConfiguration<Livro>
	{
		public void Configure(EntityTypeBuilder<Livro> builder)
		{
			builder.HasKey(l => l.FilmeId);
			builder.Property(l => l.FilmeId).IsRequired().UseIdentityColumn();
			builder.Property(l => l.Autor).IsRequired().HasMaxLength(128);
			builder.Property(l => l.GeneroId).IsRequired();
			builder.Property(l => l.AnoLancamento).IsRequired().IsFixedLength().HasMaxLength(4);
			builder.Property(l => l.NumeroPaginas).IsRequired();
			builder.Property(l => l.Preco).IsRequired().HasColumnType("decimal(6,2)");
			builder.Property(l => l.Editora).IsRequired().HasMaxLength(128);
			builder.Property(l => l.Titulo).IsRequired().HasMaxLength(128);
		}
	}
}
