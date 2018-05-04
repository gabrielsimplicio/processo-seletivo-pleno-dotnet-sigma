using GerenciadorDePatrimonios.Domain.Entities;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Application.Interface
{
    public interface IModeloAppService : IAppServiceBase<Modelo>
    {
        IEnumerable<Modelo> BuscarPorId(int id);
        List<Modelo> BuscarPorNome(string nome, int id);
        List<Modelo> BuscarPorMarcaId(int id);
    }
}
