using System.Collections.Generic;
using ProjetoSigma.Domain.Entities;

namespace ProjetoSigma.Domain.Services.Interface
{
    public interface IPatrimonioService : IBaseService<PatrimonioDomain>
    {
        IEnumerable<PatrimonioDomain> GetPatrimonioByMarca(int marcaId);
        IEnumerable<PatrimonioDomain> GetPatrimonioByModelo(int modeloId);
    }
}