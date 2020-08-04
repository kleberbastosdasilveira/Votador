using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VotadorWeb.ViewModels
{
    public class RegistroVotacaoViewModel
    {
		[Key]
		[HiddenInput]
		public Guid FuncionarioId { get; set; }
		public FuncionarioViewModel Funcionario { get; set; }

		[Key]
		[HiddenInput]
		public Guid RecursoId { get; set; }
		public RecursoViewModel Recurso { get; set; }

		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(999, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 5)]
		public string ComentarioRecurso { get; set; }

		[ScaffoldColumn(false)]
		[DisplayName("Data da Votação")]
		public DateTime DataVotacaoRecurso { get; set; }
	}
}
