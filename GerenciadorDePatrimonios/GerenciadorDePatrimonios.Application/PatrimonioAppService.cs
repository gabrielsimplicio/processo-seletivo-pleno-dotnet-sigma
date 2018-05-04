using GerenciadorDePatrimonios.Application.Interface;
using GerenciadorDePatrimonios.Domain.Entities;
using GerenciadorDePatrimonios.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Application
{

    public class PatrimonioAppService : AppServiceBase<Patrimonio>, IPatrimonioAppService
    {
        private readonly IPatrimonioService _patrimonioService;

        public PatrimonioAppService(IPatrimonioService patrimonioService)
            : base(patrimonioService)
        {
            _patrimonioService = patrimonioService;
        }

        public IEnumerable<Patrimonio> BuscarPorId(int id)
        {
            return _patrimonioService.BuscarPorId(id);
        }

        public IEnumerable<Patrimonio> BuscarPorMarcaId(int id)
        {
            return _patrimonioService.BuscarPorMarcaId(id);
        }

        public IEnumerable<Patrimonio> BuscarPorModelo(int modeloId)
        {
            return _patrimonioService.BuscarPorModelo(modeloId);
        }

    }
}
