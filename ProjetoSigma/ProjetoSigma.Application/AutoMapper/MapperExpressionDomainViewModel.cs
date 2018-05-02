using System;
using System.Linq.Expressions;
using AutoMapper;
using ProjetoSigma.Application.ViewModel;
using ProjetoSigma.Domain.Entities;

namespace ProjetoSigma.Application.AutoMapper
{
    public class MapperExpressionDomainViewModel : Profile
    {
        public MapperExpressionDomainViewModel()
        {
            CreateMap<Expression<Func<MarcaDomain, bool>>, Expression<Func<MarcaViewModel, bool>>>().ReverseMap();
            CreateMap<Expression<Func<ModeloDomain, bool>>, Expression<Func<ModeloViewModel, bool>>>().ReverseMap();
            CreateMap<Expression<Func<PatrimonioDomain, bool>>, Expression<Func<PatrimonioViewModel, bool>>>().ReverseMap();
        }
    }
}