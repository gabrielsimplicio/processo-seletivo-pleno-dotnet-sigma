using AutoMapper;
using MeuPatrimonio.Application.Interfaces;
using MeuPatrimonio.Domain.DTOs;
using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Services.Interfaces;

namespace MeuPatrimonio.Application
{
    public class MarcaApplication : ApplicationBase<Marca, MarcaDTO>, IMarcaApplication
    {
        public MarcaApplication(IMarcaService service) : base(service)
        {
        }

        public override MarcaDTO Update(MarcaDTO entityDTO)
        {
            var marca = Service.GetById(entityDTO.Id);
            marca.Nome = entityDTO.Nome;
            return Mapper.Map<MarcaDTO>(Service.Update(marca));
        }
    }
}
