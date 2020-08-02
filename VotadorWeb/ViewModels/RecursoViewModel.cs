using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VotadorWeb.ViewModels
{
    public class RecursoViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Título do Recurso")]
        [Required(ErrorMessage = "O critério {0} é obrigatório")]
        [StringLength(50,ErrorMessage = "O campo {0} precisa ter no entre de {2} e o máximo de {1} caractéres", MinimumLength =10)]
        public string TituloRecurso { get; set; }

        [DisplayName("Descrição do Recurso")]
        [Required(ErrorMessage ="O critério {0} é obrigatório")]
        [StringLength(999,ErrorMessage = "O campo {0} precisa ter no entre de {2} e o máximo de {1} caractéres", MinimumLength =10)]
        public string DescricaoRecurso { get; set; }

        [DisplayName("Quantidade de Voto")]
        public int NumeroVotacao { get; set; }
  

        public IEnumerable<RegistroVotacaoViewModel> RegistroVotacoes { get; set; }
    }
}
