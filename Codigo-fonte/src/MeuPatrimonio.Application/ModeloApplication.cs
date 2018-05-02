using AutoMapper;
using MeuPatrimonio.Application.Interfaces;
using MeuPatrimonio.Domain.DTOs;
using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Services.Interfaces;

namespace MeuPatrimonio.Application
{
    public class ModeloApplication : ApplicationBase<Modelo, ModeloDTO>, IModeloApplication
    {
        public ModeloApplication(IModeloService service) : base(service)
        {
        }

        public override ModeloDTO Update(ModeloDTO entityDTO)
        {
            var Modelo = Service.GetById(entityDTO.Id);
            Modelo.Nome = entityDTO.Nome;
            Modelo.MarcaId = entityDTO.MarcaId;
            return Mapper.Map<ModeloDTO>(Service.Update(Modelo));
        }
    }
}
