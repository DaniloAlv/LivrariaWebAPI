using Livraria.Data.Dtos;
using Livraria.Data.Interfaces;
using Livraria.Data.ViewModels;
using Livraria.Domain.Entities;
using Livraria.UseCases.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Livraria.WebApi.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LivroController : ControllerBase
	{
		private readonly ILivroUseCases _livroUseCases;

		public LivroController(ILivroUseCases livroUseCases)
		{
			_livroUseCases = livroUseCases;
		}

		// GET: api/<LivroController>
		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
			try
			{
				IEnumerable<LivroViewModel> livros = await _livroUseCases.GetAllLivros();
				return Ok(livros);
			}
			catch (NullReferenceException ex)
			{
				return NotFound(ex.Message);
			}
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> Get(int id)
		{
			try
			{
				LivroViewModel livro = await _livroUseCases.GetLivro(id);
				return Ok(livro);
			}
			catch (ArgumentNullException ex)
			{
				return NotFound(ex.Message);
			}
		}

		// POST api/<LivroController>
		[HttpPost]
		public async Task<IActionResult> Post([FromBody] LivroDto livro)
		{
			try
			{
				LivroViewModel livroModel = await _livroUseCases.CreateAsync(livro);
				return Created("Livro cadastrado com sucesso!", livroModel);
			}
			catch (Exception ex)
			{
				return BadRequest("Não foi possível cadastrar o livro!");
			}
		}

		// PUT api/<LivroController>/5
		[HttpPut("{id}")]
		public async Task<IActionResult> Put(int id, [FromBody] LivroDto livro)
		{
			try
			{
				LivroViewModel model = await _livroUseCases.GetLivro(id);
				if(model != null)
				{
					await _livroUseCases.UpdateAsync(livro);
					return Ok(livro);
				}

				return NotFound("Livro não encontrado!");
			}
			catch (Exception ex)
			{
				return BadRequest($"Foi encontrado o seguinte erro: {ex.Message}");
			}
		}

		// DELETE api/<LivroController>/5
		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			try
			{
				LivroViewModel livro = await _livroUseCases.GetLivro(id);

				if(livro != null)
				{
					_livroUseCases.Delete(livro);
					return Ok();
				}

				return NotFound("Livro não encontrado para exclusão");
			}
			catch (ArgumentNullException ex)
			{
				return NotFound(ex.Message);
			}
		}
	}
}
