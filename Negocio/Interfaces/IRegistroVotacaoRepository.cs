﻿using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRegistroVotacaoRepository : IRepository<RegistroVotacao> 
    {
        Task<IEnumerable<RegistroVotacao>> ObterVotacaoPorFuncionario(Guid funcionarioId);
        Task<IEnumerable<RegistroVotacao>> ObterVotacaoPorRecurso(Guid recursoId);
        Task<IEnumerable<RegistroVotacao>> ObterVotacaoPorRecursoEFuncionario();
    }
}