using Business.Models;
using System;
using System.Threading.Tasks;

namespace Business.Interfaces.IService
{
    public interface IRegistroVotacaoService : IDisposable
    {
        Task Adicionar(RegistroVotacao registroVotacao);
    }
}