using AutoMapper;
using MeuPatrimonio.Domain.DTOs;
using MeuPatrimonio.Domain.Entities;

namespace MeuPatrimonio.Application.AutoMapper
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(mapper =>
            {
                mapper.CreateMap<MarcaDTO, Marca>();
                mapper.CreateMap<Marca, MarcaDTO>();
            });
        }
    }
}
