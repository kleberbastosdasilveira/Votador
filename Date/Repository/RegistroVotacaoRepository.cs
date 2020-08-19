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
    public class RegistroVotacaoRepository : Repository<RegistroVotacao>, IRegistroVotacaoRepository
    {
        public RegistroVotacaoRepository(MeuDbContext context) : base(context) { }

        public async Task<RegistroVotacao> ObterVotacao(Guid funcionarioId, Guid recursoId)
        {
            return await (from r in Db.RegistroVotacoes.AsNoTracking()
                          join rc in Db.Recursos.AsNoTracking() on r.RecursoId equals rc.Id
                          join f in Db.Funcionarios.AsNoTracking() on r.FuncionarioId equals f.Id
                          where r.FuncionarioId == funcionarioId && r.RecursoId == recursoId
                          select r).OrderByDescending(r => r.DataVotacaoRecurso).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<RegistroVotacao>> ObterVotacaoPorFuncionario(Guid funcionarioId)
        {
            return await (from r in Db.RegistroVotacoes.AsNoTracking()
                          join f in Db.Funcionarios.AsNoTracking() on r.FuncionarioId equals f.Id
                          where r.FuncionarioId == funcionarioId
                          select r).ToListAsync();
        }

        public async Task<IEnumerable<RegistroVotacao>> ObterVotacaoPorRecurso(Guid recursoId)
        {
            return await (from r in Db.RegistroVotacoes.AsNoTracking()
                          join rc in Db.Recursos.AsNoTracking() on r.RecursoId equals rc.Id
                          where r.RecursoId == recursoId
                          select r).ToListAsync();
        }

        public async Task<RegistroVotacao> ObterVotoPorFuncionario(Guid funcionarioId, Guid recursoId)
        {
            return await Db.RegistroVotacoes.AsNoTracking().FirstOrDefaultAsync(r => r.FuncionarioId == funcionarioId && r.RecursoId == recursoId);
        }
    }
}
