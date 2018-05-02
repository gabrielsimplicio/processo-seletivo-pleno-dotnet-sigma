using System.Runtime.InteropServices.WindowsRuntime;
using ProjetoSigma.Domain.Entities;
using ProjetoSigma.Domain.Services.Interface;
using ProjetoSigma.Infra.Data.Interface;

namespace ProjetoSigma.Domain.Services.Service
{
    public class MarcaService : BaseService<MarcaDomain>, IMarcaService
    {
        public MarcaService(IBaseRepository<MarcaDomain> repository) : base(repository)
        {
        }


        MarcaDomain IBaseService<MarcaDomain>.Add(MarcaDomain model)
        {
            if (model.Validate())
                return Add(model);

            return model;
        }

        MarcaDomain IBaseService<MarcaDomain>.Update(MarcaDomain model)
        {
            if (model.Validate())
                return Update(model);

            return model;
        }
    }
}