using GerenciadorDePatrimonios.Domain.Entities;
using GerenciadorDePatrimonios.Domain.Interfaces.Repositories;
using GerenciadorDePatrimonios.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Domain.Services
{
    public class ModeloService : ServiceBase<Modelo>, IModeloService
    {
        private readonly IModeloRepository _modeloRepository;

        public ModeloService(IModeloRepository modeloRepository)
            : base(modeloRepository)
        {
            _modeloRepository = modeloRepository;
        }

        public IEnumerable<Modelo> BuscarPorId(int Id)
        {
            return _modeloRepository.BuscarPorId(Id);
        }
    }
}
