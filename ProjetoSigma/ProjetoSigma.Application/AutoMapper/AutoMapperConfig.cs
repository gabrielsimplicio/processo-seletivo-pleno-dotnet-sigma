using AutoMapper;

namespace ProjetoSigma.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(m =>
            {
                m.AddProfile(new MapperDomainViewModel());
                m.AddProfile(new MapperExpressionDomainViewModel());
            });
        }
    }
}