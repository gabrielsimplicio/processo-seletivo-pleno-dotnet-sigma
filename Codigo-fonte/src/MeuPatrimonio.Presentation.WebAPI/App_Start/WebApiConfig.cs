using MeuPatrimonio.Application;
using MeuPatrimonio.Application.Interfaces;
using MeuPatrimonio.Domain.Repositories.Interfaces;
using MeuPatrimonio.Domain.Services;
using MeuPatrimonio.Domain.Services.Interfaces;
using MeuPatrimonio.Domain.Validations;
using MeuPatrimonio.Domain.Validations.Interfaces;
using MeuPatrimonio.Infra.CrossCutting.AutoMapper;
using MeuPatrimonio.Infra.Data.Interfaces;
using MeuPatrimonio.Infra.Data.ORM.EntityFramework.Contexts;
using MeuPatrimonio.Infra.Data.Repositories;
using System.Net.Http.Headers;
using System.Web.Http;
using Unity;
using Unity.Lifetime;
using Unity.WebApi;

namespace MeuPatrimonio.Presentation.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            config.Formatters.JsonFormatter.SupportedMediaTypes
                .Add(new MediaTypeHeaderValue("text/html"));

            AutoMapperConfiguration.Configure();

            var container = new UnityContainer();

            container.RegisterType<IDatasourceContext, MeuPatrimonioContext>(new HierarchicalLifetimeManager());

            container.RegisterType<IMarcaApplication, MarcaApplication>(new HierarchicalLifetimeManager());
            container.RegisterType<IMarcaService, MarcaService>(new HierarchicalLifetimeManager());
            container.RegisterType<IMarcaRepository, MarcaRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IMarcaValidation, MarcaValidation>(new HierarchicalLifetimeManager());

            config.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
