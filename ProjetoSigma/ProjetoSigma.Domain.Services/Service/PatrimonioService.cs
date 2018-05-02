using System.Collections.Generic;
using ProjetoSigma.Domain.Entities;
using ProjetoSigma.Domain.Services.Interface;
using ProjetoSigma.Infra.Data.Interface;

namespace ProjetoSigma.Domain.Services.Service
{
    public class PatrimonioService : BaseService<PatrimonioDomain>, IPatrimonioService
    {
        private readonly IPatrimonioRepository _repository;
        public PatrimonioService(IPatrimonioRepository repository) : base(repository)
        {
            _repository = repository;
        }

        PatrimonioDomain IBaseService<PatrimonioDomain>.Add(PatrimonioDomain model)
        {
            if (model.Validate())
                return Add(model);

            return model;
        }

        PatrimonioDomain IBaseService<PatrimonioDomain>.Update(PatrimonioDomain model)
        {
            if (model.Validate())
                return Update(model);

            return model;
        }

        public IEnumerable<PatrimonioDomain> GetPatrimonioByMarca(int marcaId)
        {
            return _repository.GetPatrimonioByMarca(marcaId);
        }

        public IEnumerable<PatrimonioDomain> GetPatrimonioByModelo(int modeloId)
        {
            return _repository.GetPatrimonioByModelo(modeloId);
        }
    }
}