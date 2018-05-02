using System.Collections.Generic;
using ProjetoSigma.Domain.Entities;

namespace ProjetoSigma.Infra.Data.Interface
{
    public interface IPatrimonioRepository : IBaseRepository<PatrimonioDomain>
    {
        IEnumerable<PatrimonioDomain> GetPatrimonioByMarca(int marcaId);
        IEnumerable<PatrimonioDomain> GetPatrimonioByModelo(int modeloId);
    }
}