using System.Collections.Generic;
using ProjetoSigma.Domain.Entities;
using ProjetoSigma.Infra.Data.Context;
using ProjetoSigma.Infra.Data.Interface;

namespace ProjetoSigma.Infra.Data.Repository
{
    public class PatrimonioRepository : BaseRepository<PatrimonioDomain>, IPatrimonioRepository
    {
        public PatrimonioRepository(SigmaContext sigmaContext) : base(sigmaContext)
        {
        }

        public IEnumerable<PatrimonioDomain> GetPatrimonioByMarca(int marcaId)
        {
            return GetAll(m => m.MarcaId == marcaId);
        }

        public IEnumerable<PatrimonioDomain> GetPatrimonioByModelo(int modeloId)
        {
            return GetAll(m => m.ModeloId == modeloId);
        }
    }
}