using AutoMapper;
using Business.Interfaces;
using Business.Interfaces.IService;
using Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VotacaoAPI.ViewModels;

namespace VotacaoAPI.Controllers
{
    [Route("api/[controller]")]
    public class RecursosController : MainController
    {
        private readonly IRecursoRepository _recursoRepository;
        private readonly IMapper _mapper;
        private readonly IRecursoService _recursoService;

        public RecursosController(IRecursoRepository recursoRepository,
                                   IMapper mapper,
                                   INotificador notificador,
                                   IRecursoService recursoService) : base(notificador)
        {
            _mapper = mapper;
            _recursoRepository = recursoRepository;
            _recursoService = recursoService;
        }

        [HttpGet]
        public async Task<IEnumerable<RecursoViewModel>> ObterTodosRecurso()
        {
            var recurso = _mapper.Map<IEnumerable<RecursoViewModel>>(await _recursoRepository.ObterTodos());
            return recurso;
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<RecursoViewModel>> ObterPorId(Guid id)
        {
            var recurso = await ObterRecursos(id);
            if (recurso == null) return NotFound();
            return recurso;
        }
        [HttpPost]
        public async Task<ActionResult<RecursoViewModel>> AdicionarRecurso(RecursoViewModel recursoViewModel)
        {
            if (!ModelState.IsValid) return CustomeResponse(ModelState);
            await _recursoService.Adicionar(_mapper.Map<Recurso>(recursoViewModel));
            return CustomeResponse(recursoViewModel);
        }
        [HttpPut("{id:guid}")]
        public async Task<ActionResult<RecursoViewModel>>AtualizarRecurso(Guid id,RecursoViewModel recursoViewModel)
        {
            if(id!=recursoViewModel.Id )
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomeResponse(recursoViewModel);
            }
            if (!ModelState.IsValid) return CustomeResponse(ModelState);
            await _recursoRepository.Atualizar(_mapper.Map<Recurso>(recursoViewModel));
            return CustomeResponse(recursoViewModel);
        }

        protected async Task<RecursoViewModel> ObterRecursos(Guid id)
        {
            return _mapper.Map<RecursoViewModel>(await _recursoRepository.ObterPorId(id));
        }
    }
}