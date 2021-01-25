using Livraria.Data.Context;
using Livraria.Data.Interfaces;
using Livraria.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Data.Repositorys
{
	public class LivroRepository : ILivroRepository
	{
		private readonly LivrariaDbContext _livrariaDbContext;

		public LivroRepository(LivrariaDbContext livrariaDbContext)
		{
			_livrariaDbContext = livrariaDbContext;
		}

		public async Task CreateAsync(Livro livro)
		{
			await _livrariaDbContext.AddAsync(livro);
		}

		public void Delete(Livro livro)
		{
			 _livrariaDbContext.Set<Livro>().Remove(livro);
		}

		public async Task<IEnumerable<Livro>> GetAllAsync()
		{
			return await _livrariaDbContext.Set<Livro>().ToListAsync();
		}

		public async Task<Livro> GetByIdAsync(int id)
		{
			return await _livrariaDbContext.Set<Livro>()
				.FindAsync(id);
		}

		public void Update(Livro livro)
		{
			_livrariaDbContext.Set<Livro>().Update(livro);
		}

		public async Task<bool> SaveChangesAsync()
		{
			return await _livrariaDbContext.SaveChangesAsync() > 0;
		}
	}
}
