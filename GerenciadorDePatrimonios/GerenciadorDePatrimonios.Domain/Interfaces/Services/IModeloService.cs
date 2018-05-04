using GerenciadorDePatrimonios.Domain.Entities;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Domain.Interfaces.Services
{
    public interface IModeloService : IServiceBase<Modelo>
    {
        IEnumerable<Modelo> BuscarPorId(int id);
        List<Modelo> BuscarPorNome(string nome,int marcaId);
        List<Modelo> BuscarPorMarcaId(int id);
    }
}