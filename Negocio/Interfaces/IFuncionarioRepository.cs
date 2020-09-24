using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Task<Funcionario> ObterFuncionario(Guid id);

        Task<IEnumerable<Funcionario>> ObterFuncionarios();

        Task<Funcionario> ObterFuncionarioLogado(string email);
    }
}