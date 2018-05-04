using GerenciadorDePatrimonios.Application.Interface;
using GerenciadorDePatrimonios.Domain.Entities;
using GerenciadorDePatrimonios.Domain.Interfaces.Services;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Application
{
    public class MarcaAppService : AppServiceBase<Marca>, IMarcaAppService
    {
        private readonly IMarcaService _marcaService;

        public MarcaAppService(IMarcaService marcaService)
            : base(marcaService)
        {
            _marcaService = marcaService;
        }

        public IEnumerable<Marca> BuscarPorId(int id)
        {
            return _marcaService.BuscarPorId(id);
        }

        public List<Marca> BuscarPorNome(string nome)
        {
            return _marcaService.BuscarPorNome(nome);
        }
    }
}
