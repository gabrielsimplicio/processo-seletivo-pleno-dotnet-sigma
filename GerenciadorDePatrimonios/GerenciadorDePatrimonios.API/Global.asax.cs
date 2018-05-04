using AutoMapper;
using GerenciadorDePatrimonios.API.Models;
using GerenciadorDePatrimonios.Domain.Entities;
using System.Web.Http;
using System.Web.Mvc;

namespace GerenciadorDePatrimonios.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);

            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Marca, MarcaModel>();
                cfg.CreateMap<Modelo, ModeloModel>();
            });
        }
    }
}
