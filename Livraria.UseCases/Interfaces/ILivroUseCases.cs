using Livraria.Data.Dtos;
using Livraria.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.UseCases.Interfaces
{
	public interface ILivroUseCases
	{
		Task<IEnumerable<LivroViewModel>> GetAllLivros();
		Task<LivroViewModel> GetLivro(int id);
		Task<LivroViewModel> CreateAsync(LivroDto livro);
		Task UpdateAsync(LivroDto livro);
		Task Delete(LivroViewModel livro);
	}
}
