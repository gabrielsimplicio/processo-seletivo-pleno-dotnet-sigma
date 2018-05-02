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
                mapper.CreateMap<MarcaDTO, Marca>();
                mapper.CreateMap<Expression<Func<MarcaDTO, bool>>, Expression<Func<Marca, bool>>>();


                mapper.CreateMap<Marca, MarcaDTO>();
                mapper.CreateMap<IList<Marca>, IList<MarcaDTO>>();
                mapper.CreateMap<Expression<Func<Marca, bool>>, Expression<Func<MarcaDTO, bool>>>();
            });
        }
    }
}
