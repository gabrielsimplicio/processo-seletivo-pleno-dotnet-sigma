using System;
using System.Linq.Expressions;
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

        public override Expression<Func<Modelo, bool>> CreateQueryExpression(ModeloDTO filter)
        {
            if (filter != null)
            {
                if (filter.MarcaId > 0)
                {
                    return (c => c.MarcaId == filter.MarcaId);
                }
            }
            return null;
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
