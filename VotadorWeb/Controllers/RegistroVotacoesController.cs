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
    public class RegistroVotacoesController : BaseController
    {
        private readonly IRegistroVotacaoRepository _registroVotacaoRepository;
        private readonly IRecursoRepository _recursoRepository;
        private readonly IMapper _mapper;

        public RegistroVotacoesController(IRegistroVotacaoRepository registroVotacaoRepository,IRecursoRepository recursoRepository ,IMapper mapper)
        {
            _mapper = mapper; _registroVotacaoRepository = registroVotacaoRepository; _recursoRepository = recursoRepository;
        }

        // GET: RegistroVotacoes
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistroVotacoes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistroVotacoes/Create
        public async Task<IActionResult> Create(Guid id)
        {
            var recursoViewModel = await ObterRecursoPorId(id);
            if (recursoViewModel == null)
                return NotFound();

            return View();
        }

        // POST: RegistroVotacoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RegistroVotacaoViewModel registroVotacaoViewModel)
        {
            try
            {   
                if (!ModelState.IsValid) return NotFound();
                var registro = _mapper.Map<RegistroVotacao>(registroVotacaoViewModel);
                await _registroVotacaoRepository.Adicionar(registro);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroVotacoes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistroVotacoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroVotacoes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistroVotacoes/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

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