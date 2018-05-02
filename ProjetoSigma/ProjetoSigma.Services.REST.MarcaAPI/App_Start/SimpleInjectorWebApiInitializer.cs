using System.Web.Http;
using ProjetoSigma.Infra.CrossCutting.IoC;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

[assembly: WebActivator.PostApplicationStartMethod(typeof(ProjetoSigma.Services.REST.MarcaAPI.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace ProjetoSigma.Services.REST.MarcaAPI.App_Start
{
    public static class SimpleInjectorWebApiInitializer
    {
        /// <summary>Initialize the container and register it as Web API Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            SimpleInjectorBootstrapper.Register(container);
        }
    }
}