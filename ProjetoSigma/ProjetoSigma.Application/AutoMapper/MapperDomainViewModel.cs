using AutoMapper;
using ProjetoSigma.Application.ViewModel;
using ProjetoSigma.Domain.Entities;

namespace ProjetoSigma.Application.AutoMapper
{
    public class MapperDomainViewModel : Profile
    {
        public MapperDomainViewModel()
        {
            CreateMap<MarcaDomain, MarcaViewModel>().ReverseMap();
            CreateMap<ModeloDomain, ModeloViewModel>().ReverseMap();

            CreateMap<PatrimonioDomain, PatrimonioViewModel>().ReverseMap();
        }
    }
}