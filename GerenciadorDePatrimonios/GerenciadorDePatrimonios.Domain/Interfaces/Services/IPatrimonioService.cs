using GerenciadorDePatrimonios.Domain.Entities;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Domain.Interfaces.Services
{
    public interface IPatrimonioService : IServiceBase<Patrimonio>
    {
        IEnumerable<Patrimonio> BuscarPorId(int id);
        IEnumerable<Patrimonio> BuscarPorMarcaId(int id);
        IEnumerable<Patrimonio> BuscarPorModelo(int modeloId);
    }
}