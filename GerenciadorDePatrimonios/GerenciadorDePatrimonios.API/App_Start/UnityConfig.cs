using GerenciadorDePatrimonios.Application;
using GerenciadorDePatrimonios.Application.Interface;
using GerenciadorDePatrimonios.Domain.Interfaces.Repositories;
using GerenciadorDePatrimonios.Domain.Interfaces.Services;
using GerenciadorDePatrimonios.Domain.Repositories;
using GerenciadorDePatrimonios.Domain.Services;
using GerenciadorDePatrimonios.Infra.Data.Repositories;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace GerenciadorDePatrimonios.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType(typeof(IAppServiceBase<>), (typeof(AppServiceBase<>)));
            container.RegisterType(typeof(IMarcaAppService), (typeof(MarcaAppService)));
            container.RegisterType(typeof(IModeloAppService), (typeof(ModeloAppService)));


            container.RegisterType(typeof(IServiceBase<>), (typeof(ServiceBase<>)));
            container.RegisterType(typeof(IMarcaService), (typeof(MarcaService)));
            container.RegisterType(typeof(IModeloService), (typeof(ModeloService)));


            container.RegisterType(typeof(IRepositoryBase<>), (typeof(RepositoryBase<>)));
            container.RegisterType(typeof(IMarcaRepository), (typeof(MarcaRepository)));
            container.RegisterType(typeof(IModeloRepository), (typeof(ModeloRepository)));


            //            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            //kernel.Bind<IMarcaService>().To<IMarcaService>();
            //            kernel.Bind<IModeloService>().To<IModeloService>();

            //            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            //kernel.Bind<IMarcaRepository>().To<IMarcaRepository>();
            //            kernel.Bind<IModeloRepository>().To<IModeloRepository>();





            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}