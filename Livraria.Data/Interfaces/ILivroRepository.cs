using Livraria.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.Data.Interfaces
{
	public interface ILivroRepository
	{
		Task<IEnumerable<Livro>> GetAllAsync();
		Task<Livro> GetByIdAsync(int id);
		Task CreateAsync(Livro livro);
		void Update(Livro livro);
		void Delete(Livro livro);
		Task<bool> SaveChangesAsync();
	}
}
