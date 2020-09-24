using System.Collections.Generic;

namespace Business.Models
{
    public class Recurso : Entity
    {
        public string TituloRecurso { get; set; }
        public string DescricaoRecurso { get; set; }
        public int NumeroVotacao { get; set; }
        public IEnumerable<RegistroVotacao> RegistroVotacoes { get; set; }
    }
}