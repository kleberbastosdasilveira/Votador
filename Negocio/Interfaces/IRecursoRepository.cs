using Business.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IRecursoRepository : IRepository<Recurso>
    {
        Task<Recurso> ObterRecurso(Guid id);

        Task<IEnumerable<Recurso>> ObterTodosVotos();
    }
}