using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Repositories.Interfaces;
using MeuPatrimonio.Infra.Data.Interfaces;

namespace MeuPatrimonio.Infra.Data.Repositories
{
    public class ModeloRepository : RepositoryBase<Modelo>, IModeloRepository
    {
        public ModeloRepository(IDatasourceContext context) : base(context)
        {
        }
    }
}
