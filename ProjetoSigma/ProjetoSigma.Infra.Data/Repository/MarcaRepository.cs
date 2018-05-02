using ProjetoSigma.Domain.Entities;
using ProjetoSigma.Infra.Data.Context;
using ProjetoSigma.Infra.Data.Interface;

namespace ProjetoSigma.Infra.Data.Repository
{
    public class MarcaRepository : BaseRepository<MarcaDomain>, IMarcaRepository
    {
        public MarcaRepository(SigmaContext sigmaContext) : base(sigmaContext)
        {
        }
    }
}