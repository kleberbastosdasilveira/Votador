using Business.Interfaces;
using Business.Models;
using Date.Context;
using Date.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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

        public async Task<Funcionario> ObterFuncionario(Guid id)
        {
            return await Db.Funcionarios.AsNoTracking().FirstOrDefaultAsync(f => f.Id == id);
        }

        public async Task<Funcionario> ObterFuncionarioLogado(string email, string senha)
        {
            var usuario = await Db.Funcionarios.AsNoTracking().FirstOrDefaultAsync(f => f.Email == email && f.Senha == new Cryptography().DecryptCardData(senha));
            if (usuario != null)
                return usuario;
            else
                return null;
        }

        public async Task<IEnumerable<Funcionario>> ObterFuncionarios()
        {
            return await Db.Funcionarios.AsNoTracking().OrderBy(f=>f.Nome).ToListAsync();
        }

    }
}
