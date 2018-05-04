using AutoMapper;
using GerenciadorDePatrimonios.API.Models;
using GerenciadorDePatrimonios.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

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
