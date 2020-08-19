using Business.Interfaces;
using Business.Notificacoes;
using FluentValidation;
using FluentValidation.Results;

namespace Business.Services
{
    public abstract class BaseService
    {
        private readonly INotificador _notificador;
        public BaseService(INotificador notificador)
        {
            _notificador = notificador;
        }
        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var erro in validationResult.Errors)
            {
                Notificar(erro.ErrorMessage);
            }
        }

        protected void Notificar(string mesagem)
        {
            _notificador.Handle(new Notificacao(mesagem));
        }

        protected bool ExecultarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : class
        {
            var validator = validacao.Validate(entidade);
            if (validator.IsValid) return true;
            Notificar(validator);
            return false;
        }
    }
}