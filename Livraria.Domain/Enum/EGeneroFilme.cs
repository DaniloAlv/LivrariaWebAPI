using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Livraria.Domain.Enum
{
	public enum EGeneroFilme
	{
		[Description("Aventura")]
		Aventura = 1,

		[Description("Ação")]
		Acao = 2,

		[Description("Mistério")]
		Misterio = 3,

		[Description("Ficção")]
		Ficcao = 4,

		[Description("Suspense")]
		Suspense = 5,

		[Description("Terror")]
		Terror = 6,

		[Description("Auto Ajuda")]
		AutoAjuda = 7,

		[Description("Biografia")]
		Biografia = 8,

		[Description("Cientifico")]
		Cientifico = 9,

		[Description("Contos/Crônicas")]
		ContosCronicas = 10,

		[Description("Erotismo")]
		Erotismo = 11,

		[Description("Romance")]
		Romance = 12,

		[Description("Comédia")]
		Comedia = 13,

		[Description("Drama")]
		Drama = 14
	}
}
