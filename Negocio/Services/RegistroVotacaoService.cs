using Business.Interfaces;
using Business.Interfaces.IService;
using Business.Models;
using Business.Models.Validations;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services
{
    public class RegistroVotacaoService : BaseService, IRegistroVotacaoService
    {
        private readonly IRegistroVotacaoRepository _registroVotacaoRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IFuncionarioRepository _funcionarioRepository;
        private readonly IRecursoRepository _recursoRepository;

        public RegistroVotacaoService(
                IRegistroVotacaoRepository registroVotacaoRepository,
                IHttpContextAccessor httpContextAccessor,
                IFuncionarioRepository funcionarioRepository,
                IRecursoRepository recursoRepository,
                INotificador notificador) : base(notificador)
        {
            _registroVotacaoRepository = registroVotacaoRepository;
            _httpContextAccessor = httpContextAccessor;
            _funcionarioRepository = funcionarioRepository;
            _recursoRepository = recursoRepository;
        }

        public async Task Adicionar(RegistroVotacao registroVotacao)
        {
            if (!ExecultarValidacao(new RegistroVotacaoValidation(), registroVotacao)) return;
            var useridentitylogado = _httpContextAccessor.HttpContext.User.Identity.Name.ToString();
            var usuariologado = await _funcionarioRepository.ObterFuncionarioLogado(useridentitylogado);
            var recurso = await _recursoRepository.ObterPorId(registroVotacao.RecursoId);
            if (_registroVotacaoRepository.ObterVotacao(usuariologado.Id, recurso.Id).Result.Funcionario.Nome.Any())
            {
                Notificar("Usuário já realizou votação nesse recurso.");
                return;
            }
            if (usuariologado == null)
            {
                Notificar("Usuário não encontrato.");
                return;
            }
            var atualizarecurso = new Recurso
            {
                Id = recurso.Id,
                DescricaoRecurso = recurso.DescricaoRecurso,
                NumeroVotacao = recurso.NumeroVotacao + 1,
                TituloRecurso = recurso.TituloRecurso
            };
            var registro = new RegistroVotacao
            {
                RecursoId = registroVotacao.RecursoId,
                ComentarioRecurso = registroVotacao.ComentarioRecurso,
                DataVotacaoRecurso = DateTime.Now,
                FuncionarioId = usuariologado.Id,
            };
            await _registroVotacaoRepository.Adicionar(registro);
            await _recursoRepository.Atualizar(atualizarecurso);
        }

        public void Dispose()
        {
            _registroVotacaoRepository?.Dispose();
            _funcionarioRepository?.Dispose();
            _recursoRepository?.Dispose();
        }
    }
}