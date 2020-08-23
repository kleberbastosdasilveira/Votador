﻿using Business.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace VotacaoWeb.Extensions
{
    public class Notificacao : ViewComponent
    {
        private readonly INotificador _notificador;

        public Notificacao(INotificador notificador)
        {
            _notificador = notificador;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var notificacoes = await Task.FromResult(_notificador.ObterNotificacoes());
            notificacoes.ForEach(n => ViewData.ModelState.AddModelError(string.Empty, n.Mensagem));
            return View();
        }
    }
}