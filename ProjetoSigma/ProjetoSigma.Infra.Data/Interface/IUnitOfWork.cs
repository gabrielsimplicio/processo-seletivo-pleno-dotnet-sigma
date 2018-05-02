namespace ProjetoSigma.Infra.Data.Interface
{
    public interface IUnitOfWork
    {
        void Commit();
        void BeginTransaction();
        void RollBakc();
    }
}