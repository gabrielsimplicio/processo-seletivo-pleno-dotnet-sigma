using GerenciadorDePatrimonios.Domain.Entities;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Application.Interface
{
    public interface IMarcaAppService : IAppServiceBase<Marca>
    {
        IEnumerable<Marca> BuscarPorId(int id);
        List<Marca> BuscarPorNome(string nome);
    }
}
