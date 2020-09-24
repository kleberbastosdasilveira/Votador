using System;

namespace Business.Models
{
    public class RegistroVotacao
    {
        public Guid FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }

        public Guid RecursoId { get; set; }
        public Recurso Recurso { get; set; }

        public string ComentarioRecurso { get; set; }
        public DateTime DataVotacaoRecurso { get; set; }
    }
}