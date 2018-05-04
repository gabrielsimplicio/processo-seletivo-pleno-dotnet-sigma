using GerenciadorDePatrimonios.Domain.Entities;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Domain.Interfaces.Services
{
    public interface IMarcaService : IServiceBase<Marca>
    {
        IEnumerable<Marca> BuscarPorId(int Id);
        List<Marca> BuscarPorNome(string nome);
    }
}
