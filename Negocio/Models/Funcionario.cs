using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Models
{
	public class Funcionario : Entity
	{
		public string Nome { get; set; }
		public string Email { get; set; }
		public string Senha { get; set; }
		public IEnumerable<RegistroVotacao> RegistroVotacoes { get; set; }
	}
}
