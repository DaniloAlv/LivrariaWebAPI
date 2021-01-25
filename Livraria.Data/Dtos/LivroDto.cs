using System;
using System.Collections.Generic;
using System.Text;

namespace Livraria.Data.Dtos
{
	public class LivroDto
	{
		public string Titulo { get; set; }
		public string Autor { get; set; }
		public int GeneroId { get; set; }
		public string Editora { get; set; }
		public int AnoLancamento { get; set; }
		public int NumeroPaginas { get; set; }
		public decimal Preco { get; set; }
	}
}
