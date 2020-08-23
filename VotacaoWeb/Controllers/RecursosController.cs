using AutoMapper;
using Business.Interfaces;
using Business.Interfaces.IService;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using VotacaoWeb.ViewModels;
using X.PagedList;

namespace VotacaoWeb.Controllers
{
    [Authorize]
    public class RecursosController : BaseController
    {
        private readonly IRecursoRepository _recursoRepository;
        private readonly IMapper _mapper;
        private readonly IRecursoService _recursoService;

        public RecursosController(
            IRecursoRepository recursoRepository,
            IMapper mapper,
            INotificador notificador,
            IRecursoService recursoService) : base(notificador)
        {
            _recursoRepository = recursoRepository;
            _mapper = mapper;
            _recursoService = recursoService;
        }

        [AllowAnonymous]
        [Route("lista-de-recursos")]
        public async Task<IActionResult> Index(int? pg)
        {
            int paginaAtual = pg ?? 1;
            var query = _mapper.Map<IEnumerable<RecursoViewModel>>(await _recursoRepository.ObterTodosVotos()).ToPagedList(paginaAtual, 3);
            return View(query);
        }

        [AllowAnonymous]
        public async Task<ActionResult> Details(Guid id)
        {
            var recursoViewModel = await ObterRecursoPorId(id);
            if (recursoViewModel == null)
                return NotFound();

            return View(recursoViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RecursoViewModel recursoViewModel)
        {
            try
            {
                if (!ModelState.IsValid) return View(recursoViewModel);
                var recurso = _mapper.Map<Recurso>(recursoViewModel);
                await _recursoService.Adicionar(recurso);
                if (!OperacaoValida()) return View(recursoViewModel);

                TempData["Sucesso"] = "Recurso Cadastrado com Sucesso!";

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return NotFound();
            }
        }

        public async Task<IActionResult> Editar(Guid id)
        {
            var recursoViewModel = await ObterRecursoPorId(id);
            if (recursoViewModel == null)
                return NotFound();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Editar(Guid id, RecursoViewModel recursoViewModel)
        {
            try
            {
                if (id != recursoViewModel.Id) return NotFound();
                if (!ModelState.IsValid) return NotFound();
                var recurso = _mapper.Map<Recurso>(recursoViewModel);
                await _recursoService.Atualizar(recurso);
                if (!OperacaoValida()) return View(await ObterRecursoPorId(id));
                return RedirectToAction("Index");
            }
            catch
            {
                return NotFound();
            }
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private async Task<RecursoViewModel> ObterRecursoPorId(Guid id)
        {
            return _mapper.Map<RecursoViewModel>(await _recursoRepository.ObterRecurso(id));
        }
    }
}