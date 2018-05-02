using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Repositories.Interfaces;
using MeuPatrimonio.Infra.Data.Interfaces;

namespace MeuPatrimonio.Infra.Data.Repositories
{
    public class MarcaRepository : RepositoryBase<Marca>, IMarcaRepository
    {
        public MarcaRepository(IDatasourceContext context) : base(context)
        {
        }
    }
}
