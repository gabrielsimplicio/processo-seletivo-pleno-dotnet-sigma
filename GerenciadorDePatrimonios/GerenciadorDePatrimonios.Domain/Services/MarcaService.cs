
using GerenciadorDePatrimonios.Domain.Entities;
using GerenciadorDePatrimonios.Domain.Interfaces.Repositories;
using GerenciadorDePatrimonios.Domain.Interfaces.Services;
using GerenciadorDePatrimonios.Domain.Repositories;
using System.Collections.Generic;

namespace GerenciadorDePatrimonios.Domain.Services
{
    public class MarcaService : ServiceBase<Marca>, IMarcaService
    {
        private readonly IMarcaRepository _marcaRepository;

        public MarcaService(IMarcaRepository marcaRepository)
            : base(marcaRepository)
        {
            _marcaRepository = marcaRepository;
        }

        public IEnumerable<Marca> BuscarPorId(int id)
        {
            return _marcaRepository.BuscarPorId(id);
        }

        public List<Marca> BuscarPorNome(string nome)
        {
            return _marcaRepository.BuscarPorNome(nome);
        }
    }
}
