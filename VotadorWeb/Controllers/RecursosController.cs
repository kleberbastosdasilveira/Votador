using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VotadorWeb.ViewModels;

namespace VotadorWeb.Controllers
{

    public class RecursosController : BaseController
    {
        private readonly IRecursoRepository _recursoRepository;
        private readonly IMapper _mapper;
        public RecursosController(IRecursoRepository recursoRepository, IMapper mapper)
        {
            _recursoRepository = recursoRepository; _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            return View(_mapper.Map<IEnumerable<RecursoViewModel>>(await _recursoRepository.ObterTodosVotos()));
        }

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
                await _recursoRepository.Adicionar(recurso);
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

            return View(recursoViewModel);
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
                await _recursoRepository.Atualizar(recurso);

                return View(await ObterRecursoPorId(id));
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