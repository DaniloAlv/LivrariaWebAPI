using AutoMapper;
using Livraria.Data.Dtos;
using Livraria.Data.Interfaces;
using Livraria.Data.ViewModels;
using Livraria.Domain.Entities;
using Livraria.UseCases.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Livraria.UseCases.UseCases
{
	public class LivroUseCases : ILivroUseCases
	{
		private readonly ILivroRepository _livroRepository;
		private readonly IMapper _mapper;

		public LivroUseCases(ILivroRepository livroRepository, IMapper mapper)
		{
			_livroRepository = livroRepository;
			_mapper = mapper;
		}

		public async Task<LivroViewModel> CreateAsync(LivroDto livro)
		{
			Livro livroMapeado = _mapper.Map<Livro>(livro);

			await _livroRepository.CreateAsync(livroMapeado);
			await _livroRepository.SaveChangesAsync();

			return _mapper.Map<LivroViewModel>(livroMapeado);
		}

		public async Task Delete(LivroViewModel livro)
		{
			Livro livroMapeado = _mapper.Map<Livro>(livro);
			await _livroRepository.SaveChangesAsync();

			_livroRepository.Delete(livroMapeado);
		}

		public async Task<IEnumerable<LivroViewModel>> GetAllLivros()
		{
			IEnumerable<Livro> livros = await _livroRepository.GetAllAsync();
			return _mapper.Map<IEnumerable<LivroViewModel>>(livros);
		}

		public async Task<LivroViewModel> GetLivro(int id)
		{
			Livro livro = await _livroRepository.GetByIdAsync(id);
			return _mapper.Map<LivroViewModel>(livro);
		}

		public async Task UpdateAsync(LivroDto livro)
		{
			Livro livroMapeado = _mapper.Map<Livro>(livro);
			await _livroRepository.SaveChangesAsync();

			_livroRepository.Update(livroMapeado);
		}
	}
}
