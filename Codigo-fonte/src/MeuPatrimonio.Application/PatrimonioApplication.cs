using AutoMapper;
using MeuPatrimonio.Application.Interfaces;
using MeuPatrimonio.Domain.DTOs;
using MeuPatrimonio.Domain.Entities;
using MeuPatrimonio.Domain.Services.Interfaces;
using System;
using System.Linq.Expressions;

namespace MeuPatrimonio.Application
{
    public class PatrimonioApplication : ApplicationBase<Patrimonio, PatrimonioDTO>, IPatrimonioApplication
    {
        public PatrimonioApplication(IPatrimonioService service) : base(service)
        {
        }

        public override Expression<Func<Patrimonio, bool>> CreateQueryExpression(PatrimonioDTO filter)
        {
            if (filter != null)
            {
                if (filter.MarcaId > 0 && filter.ModeloId > 0)
                {
                    return (patrimonio => patrimonio.MarcaId == filter.MarcaId && patrimonio.ModeloId == filter.ModeloId);
                }
                else if (filter.MarcaId > 0)
                {
                    return (patrimonio => patrimonio.MarcaId == filter.MarcaId);
                }
                else if (filter.ModeloId > 0)
                {
                    return (patrimonio => patrimonio.ModeloId == filter.ModeloId);
                }
            }
            return null;
        }

        public override PatrimonioDTO Update(PatrimonioDTO entityDTO)
        {
            var Patrimonio = Service.GetById(entityDTO.Id);
            Patrimonio.Nome = entityDTO.Nome;
            Patrimonio.Descricao = entityDTO.Descricao;
            Patrimonio.MarcaId = entityDTO.MarcaId;
            Patrimonio.ModeloId = entityDTO.ModeloId;
            return Mapper.Map<PatrimonioDTO>(Service.Update(Patrimonio));
        }
    }
}
