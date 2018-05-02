using System.Web.Http;
using ProjetoSigma.Infra.CrossCutting.IoC;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

[assembly: WebActivator.PostApplicationStartMethod(typeof(ProjetoSigma.Services.REST.ModeloAPI.App_Start.SimpleInjectorWebApiInitializer), "Initialize")]

namespace ProjetoSigma.Services.REST.ModeloAPI.App_Start
{
    public static class SimpleInjectorWebApiInitializer
    {
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
            
            InitializeContainer(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
       
            container.Verify();
            
            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
     
        private static void InitializeContainer(Container container)
        {
            SimpleInjectorBootstrapper.Register(container);
        }
    }
}