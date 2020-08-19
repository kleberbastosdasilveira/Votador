using Business.Models;
using System;
using System.Threading.Tasks;

namespace Business.Interfaces.IService
{
    public interface IRecursoService : IDisposable
    {
        Task Adicionar(Recurso recurso);

        Task Atualizar(Recurso recurso);

        Task Excluir(Recurso recurso);
    }
}