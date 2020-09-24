using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace VotacaoAPI.ViewModels
{
    public class FuncionarioViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório ")]
        [EmailAddress(ErrorMessage = "E-mail no formato inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "****")]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Senha { get; set; }

        public IEnumerable<RegistroVotacaoViewModel> RegistroVotacoes { get; set; }
    }
}