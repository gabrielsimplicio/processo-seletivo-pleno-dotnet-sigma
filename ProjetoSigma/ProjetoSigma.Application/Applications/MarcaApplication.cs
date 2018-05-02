using ProjetoSigma.Application.Interface;
using ProjetoSigma.Application.ViewModel;
using ProjetoSigma.Domain.Entities;
using ProjetoSigma.Domain.Services.Interface;
using ProjetoSigma.Infra.Data.Interface;

namespace ProjetoSigma.Application.Applications
{
    public class MarcaApplication : BaseApplication<MarcaDomain, MarcaViewModel>, IMarcaApplication
    {
        public MarcaApplication(IBaseService<MarcaDomain> service, IUnitOfWork unitOfWork) : base(service, unitOfWork)
        {
        }
    }
}