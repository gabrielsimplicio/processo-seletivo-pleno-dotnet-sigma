using System.Runtime.InteropServices.WindowsRuntime;
using ProjetoSigma.Domain.Entities;
using ProjetoSigma.Domain.Services.Interface;
using ProjetoSigma.Infra.Data.Interface;

namespace ProjetoSigma.Domain.Services.Service
{
    public class ModeloService : BaseService<ModeloDomain>, IModeloService
    {
        public ModeloService(IBaseRepository<ModeloDomain> repository) : base(repository)
        {
        }

        ModeloDomain IBaseService<ModeloDomain>.Add(ModeloDomain model)
        {
            if (model.Validate())
                return Add(model);
            
            return model;
        }

        ModeloDomain IBaseService<ModeloDomain>.Update(ModeloDomain model)
        {
            if (model.Validate())
                return Update(model);

            return model;
        }

    }
}