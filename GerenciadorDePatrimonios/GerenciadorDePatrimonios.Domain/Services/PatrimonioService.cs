
using GerenciadorDePatrimonios.Domain.Entities;
using GerenciadorDePatrimonios.Domain.Interfaces.Repositories;
using GerenciadorDePatrimonios.Domain.Interfaces.Services;
using GerenciadorDePatrimonios.Domain.Repositories;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Domain.Services
{
    public class PatrimonioService : ServiceBase<Patrimonio>, IPatrimonioService
    {
        private readonly IPatrimonioRepository _patrimonioRepository;

        public PatrimonioService(IPatrimonioRepository patrimonioRepository)
            : base(patrimonioRepository)
        {
            _patrimonioRepository = patrimonioRepository;
        }

        public IEnumerable<Patrimonio> BuscarPorId(int id)
        {
            return _patrimonioRepository.BuscarPorId(id);
        }

        public IEnumerable<Patrimonio> BuscarPorMarcaId(int id)
        {
            return _patrimonioRepository.BuscarPorMarcaId(id);
        }

        public IEnumerable<Patrimonio> BuscarPorModelo(int modeloId)
        {
            return _patrimonioRepository.BuscarPorModelo(modeloId);
        }
    }
}
