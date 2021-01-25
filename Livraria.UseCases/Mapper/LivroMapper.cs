using AutoMapper;
using Livraria.Data.ViewModels;
using Livraria.Domain.Entities;
using Livraria.Domain.Enum;
using System;
using Livraria.UseCases.Extensions;
using Livraria.Data.Dtos;

namespace Livraria.UseCases.Mapper
{
	public class LivroMapper : Profile
	{
		public LivroMapper()
		{
			CreateMap<Livro, LivroViewModel>()
				.AfterMap<GetGeneroDescription>();

			CreateMap<LivroDto, LivroViewModel>()
				.ReverseMap();

			CreateMap<LivroDto, Livro>();
		}
	}

	public class GetGeneroDescription : IMappingAction<Livro, LivroViewModel>
	{
		public void Process(Livro source, LivroViewModel destination, ResolutionContext context)
		{
			EGeneroFilme genero = (EGeneroFilme)source.GeneroId;
			destination.Genero = genero.GetDescription();
		}
	}
}
