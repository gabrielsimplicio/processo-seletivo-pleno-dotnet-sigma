using ProjetoSigma.Application.Interface;
using ProjetoSigma.Application.ViewModel;
using ProjetoSigma.Domain.Entities;
using ProjetoSigma.Domain.Services.Interface;
using ProjetoSigma.Infra.Data.Interface;

namespace ProjetoSigma.Application.Applications
{
    public class ModeloApplication : BaseApplication<ModeloDomain, ModeloViewModel>, IModeloApplication
    {
        public ModeloApplication(IBaseService<ModeloDomain> service, IUnitOfWork unitOfWork) : base(service, unitOfWork)
        {
        }
    }
}