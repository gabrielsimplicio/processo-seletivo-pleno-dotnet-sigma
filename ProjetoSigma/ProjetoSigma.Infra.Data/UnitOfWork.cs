using ProjetoSigma.Infra.Data.Context;
using ProjetoSigma.Infra.Data.Interface;

namespace ProjetoSigma.Infra.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected SigmaContext SigmaContext;

        public UnitOfWork(SigmaContext sigmaContext)
        {
            SigmaContext = sigmaContext;
        }

        public void BeginTransaction()
        {
            SigmaContext.Database.BeginTransaction();
        }

        public void RollBakc()
        {
            SigmaContext.Database.CurrentTransaction.Rollback();
        }

        public void Commit()
        {
            SigmaContext.Database.CurrentTransaction.Commit();
            SigmaContext.SaveChanges();
        }
    }
}