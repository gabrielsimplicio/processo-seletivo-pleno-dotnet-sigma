using GerenciadorDePatrimonios.Domain.Entities;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Domain.Repositories
{
    public interface IMarcaRepository : IRepositoryBase<Marca>
    {
        IEnumerable<Marca> BuscarPorId(int Id);
        List<Marca> BuscarPorNome(string nome);
    }
}
