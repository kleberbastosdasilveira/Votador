using Business.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IFuncionarioRepository : IRepository<Funcionario>
    {
        Task<Funcionario> ObterFuncionario(Guid Id);
        Task<IEnumerable<Funcionario>> ObterFuncionarios();
        Task<IEnumerable<Funcionario>> ObterVotoPorFuncionario(Guid id);
    }
}
