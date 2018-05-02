using AutoMapper;
using MeuPatrimonio.Domain.DTOs;
using MeuPatrimonio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace MeuPatrimonio.Infra.CrossCutting.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(mapper =>
            {
                #region Marca
                mapper.CreateMap<MarcaDTO, Marca>();
                mapper.CreateMap<Expression<Func<MarcaDTO, bool>>, Expression<Func<Marca, bool>>>();


                mapper.CreateMap<Marca, MarcaDTO>();
                mapper.CreateMap<IList<Marca>, IList<MarcaDTO>>();
                mapper.CreateMap<Expression<Func<Marca, bool>>, Expression<Func<MarcaDTO, bool>>>();
                #endregion

                #region Modelo
                mapper.CreateMap<ModeloDTO, Modelo>();
                mapper.CreateMap<Expression<Func<ModeloDTO, bool>>, Expression<Func<Modelo, bool>>>();


                mapper.CreateMap<Modelo, ModeloDTO>();
                mapper.CreateMap<IList<Modelo>, IList<ModeloDTO>>();
                mapper.CreateMap<Expression<Func<Modelo, bool>>, Expression<Func<ModeloDTO, bool>>>();
                #endregion

                #region Patrimonio
                mapper.CreateMap<PatrimonioDTO, Patrimonio>()
                    .ForMember(m => m.Tombo, option => option.Ignore());
                mapper.CreateMap<Expression<Func<PatrimonioDTO, bool>>, Expression<Func<Patrimonio, bool>>>();


                mapper.CreateMap<Patrimonio, PatrimonioDTO>();
                mapper.CreateMap<IList<Patrimonio>, IList<PatrimonioDTO>>();
                mapper.CreateMap<Expression<Func<Patrimonio, bool>>, Expression<Func<PatrimonioDTO, bool>>>();
                #endregion
            });
        }
    }
}
