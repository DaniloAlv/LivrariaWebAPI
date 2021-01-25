using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Livraria.Data.Context
{
	public class LivrariaDbContext : DbContext
	{
		public LivrariaDbContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Livro> Livros { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
		}
	}
}
