﻿using AutoMapper;
using Business.Interfaces;
using Business.Interfaces.IService;
using Business.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using VotacaoWeb.ViewModels;

namespace VotacaoWeb.Controllers
{
    public class RegistroVotacoesController : Controller
    {
        private readonly IRegistroVotacaoRepository _registroVotacaoRepository;
        private readonly IMapper _mapper;
        private readonly IRegistroVotacaoService _registroVotacaoService;

        public RegistroVotacoesController(
            IRegistroVotacaoRepository registroVotacaoRepository,
            IMapper mapper,
            IHttpContextAccessor httpContextAccessor,
            IRegistroVotacaoService registroVotacaoService)
        {
            _mapper = mapper;
            _registroVotacaoRepository = registroVotacaoRepository;
            _registroVotacaoService = registroVotacaoService;
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
            ViewData["registro"] = id;
            return View();
        }

        // POST: RegistroVotacoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Guid id, RegistroVotacaoViewModel registroVotacaoViewModel)
        {
            try
            {
                var registro = new RegistroVotacaoViewModel { RecursoId = id, ComentarioRecurso = registroVotacaoViewModel.ComentarioRecurso };
                var recurso = _mapper.Map<RegistroVotacao>(registro);
                await _registroVotacaoService.Adicionar(recurso);
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
    }
}