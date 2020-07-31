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
    public class RecursoRepository : Repository<Recurso>, IRecursoRepository
    {
        public RecursoRepository(MeuDbContext context) : base(context) { }

        public async Task<Recurso> ObterRecurso(Guid id)
        {
            return await Db.Recursos.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Recurso>> ObterTodosVotos()
        {
            return await Db.Recursos.AsNoTracking().OrderByDescending(r => r.NumeroVotacao).ToListAsync();
        }
    }
}
