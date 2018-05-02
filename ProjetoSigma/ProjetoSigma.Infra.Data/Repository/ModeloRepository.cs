using ProjetoSigma.Domain.Entities;
using ProjetoSigma.Infra.Data.Context;
using ProjetoSigma.Infra.Data.Interface;

namespace ProjetoSigma.Infra.Data.Repository
{
    public class ModeloRepository : BaseRepository<ModeloDomain>, IModeloRepository
    {
        public ModeloRepository(SigmaContext sigmaContext) : base(sigmaContext)
        {
        }
    }
}