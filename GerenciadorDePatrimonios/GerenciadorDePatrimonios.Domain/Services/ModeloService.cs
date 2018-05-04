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

        public IEnumerable<Modelo> BuscarPorId(int id)
        {
            return _modeloRepository.BuscarPorId(id);
        }

        public List<Modelo> BuscarPorMarcaId(int id)
        {
            return _modeloRepository.BuscarPorMarcaId(id);
        }

        public List<Modelo> BuscarPorNome(string nome, int marcaId)
        {
            return _modeloRepository.BuscarPorNome(nome, marcaId);
        }
    }
}
