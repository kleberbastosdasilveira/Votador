using Business.Interfaces;
using Business.Interfaces.IService;
using Business.Models;
using Business.Models.Validations;
using System.Threading.Tasks;

namespace Business.Services
{
    public class RecursoService : BaseService, IRecursoService
    {
        private readonly IRecursoRepository _recursoRepository;

        public RecursoService(IRecursoRepository recursoRepository, INotificador notificador) : base(notificador)
        {
            _recursoRepository = recursoRepository;
        }

        public async Task Adicionar(Recurso recurso)
        {
            if (!ExecultarValidacao(new RecursoValidation(), recurso)) return;
            await _recursoRepository.Adicionar(recurso);
        }

        public async Task Atualizar(Recurso recurso)
        {
            if (!ExecultarValidacao(new RecursoValidation(), recurso)) return;
            await _recursoRepository.Atualizar(recurso);
        }

        public async Task Excluir(Recurso recurso)
        {
            await _recursoRepository.Remover(recurso.Id);
        }

        public void Dispose()
        {
            _recursoRepository?.Dispose();
        }
    }
}