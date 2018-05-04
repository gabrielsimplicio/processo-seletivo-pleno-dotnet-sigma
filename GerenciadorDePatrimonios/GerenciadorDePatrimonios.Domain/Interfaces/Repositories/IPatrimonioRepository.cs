using GerenciadorDePatrimonios.Domain.Entities;
using GerenciadorDePatrimonios.Domain.Repositories;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Domain.Interfaces.Repositories
{
    public interface IPatrimonioRepository : IRepositoryBase<Patrimonio>
    {
        IEnumerable<Patrimonio> BuscarPorId(int id);
        IEnumerable<Patrimonio> BuscarPorMarcaId(int id);
        IEnumerable<Patrimonio> BuscarPorModelo(int id);
    }
}