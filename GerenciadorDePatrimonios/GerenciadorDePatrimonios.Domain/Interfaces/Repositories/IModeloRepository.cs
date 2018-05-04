using GerenciadorDePatrimonios.Domain.Entities;
using GerenciadorDePatrimonios.Domain.Repositories;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Domain.Interfaces.Repositories
{
    public interface IModeloRepository : IRepositoryBase<Modelo>
    {
        IEnumerable<Modelo> BuscarPorId(int Id);
    }
}