using FluentValidation;

namespace Business.Models.Validations
{
    public class RegistroVotacaoValidation : AbstractValidator<RegistroVotacao>
    {
        public RegistroVotacaoValidation()
        {
            RuleFor(r => r.ComentarioRecurso)
                        .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                        .Length(2, 999)
                        .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}