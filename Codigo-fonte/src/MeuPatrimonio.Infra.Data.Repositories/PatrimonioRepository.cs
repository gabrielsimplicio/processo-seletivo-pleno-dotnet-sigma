using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Repositories.Interfaces;
using MeuPatrimonio.Infra.Data.Interfaces;

namespace MeuPatrimonio.Infra.Data.Repositories
{
    public class PatrimonioRepository : RepositoryBase<Patrimonio>, IPatrimonioRepository
    {
        public PatrimonioRepository(IDatasourceContext context) : base(context)
        {
        }
    }
}
