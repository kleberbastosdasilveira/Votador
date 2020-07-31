using Business.Interfaces;
using Business.Models;
using Date.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Date.Repository
{
    public class FuncionarioRepository : Repository<Funcionario>, IFuncionarioRepository
    {
        public FuncionarioRepository(MeuDbContext context) : base(context){}

        public async Task<Funcionario> ObterFuncionario(Guid Id)
        {
            return await Db.Funcionarios.AsNoTracking().FirstOrDefaultAsync(f => f.Id == Id);
        }

        public async Task<IEnumerable<Funcionario>> ObterFuncionarios()
        {
            return await Db.Funcionarios.AsNoTracking().OrderBy(f=>f.Nome).ToListAsync();
        }

        public async Task<IEnumerable<Funcionario>> ObterVotoPorFuncionario(Guid id)
        {
            return await Db.Funcionarios.AsNoTracking().Include(r => r.RegistroVotacoes).ToListAsync();
        }
    }
}
