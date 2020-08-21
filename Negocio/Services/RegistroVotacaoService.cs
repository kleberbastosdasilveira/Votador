using Business.Interfaces;
using Business.Interfaces.IService;
using Business.Models;
using Business.Models.Validations;
using Microsoft.AspNetCore.Http;
using System;
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
            var usuario = await Obterfuncionariologado();
            var recurso = await _recursoRepository.ObterPorId(registroVotacao.RecursoId);
            if (VerificarUsuarioVoto(usuario.Id,recurso.Id))
            {
                Notificar("Usuário já realizou votação nesse recurso.");
                return;
            }

            recurso.NumeroVotacao = recurso.NumeroVotacao + 1;
            var registro = new RegistroVotacao
            {
                RecursoId = registroVotacao.RecursoId,
                ComentarioRecurso = registroVotacao.ComentarioRecurso,
                DataVotacaoRecurso = DateTime.Now,
                FuncionarioId = usuario.Id,
            };
            await _registroVotacaoRepository.Adicionar(registro);
            await _recursoRepository.Atualizar(recurso);
        }

        public void Dispose()
        {
            _registroVotacaoRepository?.Dispose();
            _funcionarioRepository?.Dispose();
            _recursoRepository?.Dispose();
        }
        private async Task<Funcionario> Obterfuncionariologado ()
        {
            var useridentitylogado = _httpContextAccessor.HttpContext.User.Identity.Name.ToString();
            var usuariologado = await _funcionarioRepository.ObterFuncionarioLogado(useridentitylogado);
            if (usuariologado == null)
            {
                Notificar("Usuário não encontrato.");
                return null;
            }
            return usuariologado;
        }
        private  bool  VerificarUsuarioVoto(Guid funcionario , Guid recurso)
        {
            var votaçaofuncionario =  _registroVotacaoRepository.ObterVotoPorFuncionario(funcionario, recurso).Result;
            if (votaçaofuncionario != null)
            {
                return true;
            } 
            return false;
        }
    }
}