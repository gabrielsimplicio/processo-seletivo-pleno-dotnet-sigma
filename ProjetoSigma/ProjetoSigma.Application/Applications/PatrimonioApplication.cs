using System.Collections.Generic;
using AutoMapper;
using ProjetoSigma.Application.Interface;
using ProjetoSigma.Application.ViewModel;
using ProjetoSigma.Domain.Entities;
using ProjetoSigma.Domain.Services.Interface;
using ProjetoSigma.Infra.Data.Interface;

namespace ProjetoSigma.Application.Applications
{
    public class PatrimonioApplication : BaseApplication<PatrimonioDomain, PatrimonioViewModel>, IPatrimonioApplication
    {
        private readonly IPatrimonioService _service;

        public PatrimonioApplication(IPatrimonioService service, IUnitOfWork unitOfWork) : base(service, unitOfWork)
        {
            _service = service;
        }

        PatrimonioViewModel IBaseApplication<PatrimonioViewModel>.Add(PatrimonioViewModel model)
        {
            model.GerarTombo();
            return base.Add(model);
        }

        public IEnumerable<PatrimonioViewModel> GetPatrimonioByMarca(int marcaId)
        {
            return Mapper.Map<IEnumerable<PatrimonioViewModel>>(_service.GetPatrimonioByMarca(marcaId));
        }

        public IEnumerable<PatrimonioViewModel> GetPatrimonioByModelo(int modeloId)
        {
            return Mapper.Map<IEnumerable<PatrimonioViewModel>>(_service.GetPatrimonioByModelo(modeloId));
        }
    }
}