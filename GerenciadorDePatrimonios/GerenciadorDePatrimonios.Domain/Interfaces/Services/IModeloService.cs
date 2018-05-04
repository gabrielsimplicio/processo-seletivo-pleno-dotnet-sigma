using GerenciadorDePatrimonios.Domain.Entities;
using GerenciadorDePatrimonios.Domain.Interfaces.Repositories;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Domain.Interfaces.Services
{
    public interface IModeloService : IServiceBase<Modelo>
    {
        IEnumerable<Modelo> BuscarPorId(int Id);
    }
}