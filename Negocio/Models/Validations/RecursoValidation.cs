using FluentValidation;

namespace Business.Models.Validations
{
    public class RecursoValidation : AbstractValidator<Recurso>
    {
        public RecursoValidation()
        {
            RuleFor(r => r.TituloRecurso)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 200)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");

            RuleFor(r => r.DescricaoRecurso)
            .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
            .Length(2, 999)
            .WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}