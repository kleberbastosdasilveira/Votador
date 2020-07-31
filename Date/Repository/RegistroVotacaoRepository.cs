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
    partial class RegistroVotacaoRepository : Repository<RegistroVotacao>, IRegistroVotacaoRepository
    {
        public RegistroVotacaoRepository(MeuDbContext context) : base(context) { }

        public async Task<IEnumerable<RegistroVotacao>> ObterVotacaoPorFuncionario(Guid funcionarioId)
        {
            return await Db.RegistroVotacoes.AsNoTracking().Include(f => f.Funcionario).OrderBy(r => r.DataVotacaoRecurso).ToListAsync();
        }

        public async Task<IEnumerable<RegistroVotacao>> ObterVotacaoPorRecurso(Guid recursoId)
        {
            return await Db.RegistroVotacoes.AsNoTracking().Include(f => f.Recurso).OrderBy(r => r.DataVotacaoRecurso).ToListAsync();
        }

        public async Task<IEnumerable<RegistroVotacao>> ObterVotacaoPorRecursoEFuncionario()
        {
            return await Db.RegistroVotacoes.AsNoTracking().Include(f => f.Funcionario).Include(r => r.Recurso).ToListAsync();
        }
    }
}
