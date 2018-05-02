using System.Reflection;
using ProjetoSigma.Application.Applications;
using ProjetoSigma.Application.Interface;
using ProjetoSigma.Domain.Services.Interface;
using ProjetoSigma.Domain.Services.Service;
using ProjetoSigma.Infra.Data;
using ProjetoSigma.Infra.Data.Context;
using ProjetoSigma.Infra.Data.Interface;
using ProjetoSigma.Infra.Data.Repository;
using SimpleInjector;

namespace ProjetoSigma.Infra.CrossCutting.IoC
{
    public class SimpleInjectorBootstrapper
    {
        public static void Register(Container container)
        {
            container.Register<SigmaContext>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            Repository(container);
            Service(container);
            Application(container);
        }

        private static void Repository(Container container)
        {
            Assembly[] assemblies = { typeof(IPatrimonioRepository).Assembly };
            container.Register(typeof(IBaseRepository<>), assemblies, Lifestyle.Scoped);

            container.Register<IPatrimonioRepository, PatrimonioRepository>(Lifestyle.Scoped);
            container.Register<IMarcaRepository, MarcaRepository>(Lifestyle.Scoped);
            container.Register<IModeloRepository, ModeloRepository>(Lifestyle.Scoped);
        }

        private static void Service(Container container)
        {
            Assembly[] assemblies = { typeof(IPatrimonioService).Assembly };
            container.Register(typeof(IBaseService<>), assemblies, Lifestyle.Scoped);

            container.Register<IPatrimonioService, PatrimonioService>(Lifestyle.Scoped);
            container.Register<IMarcaService, MarcaService>(Lifestyle.Scoped);
            container.Register<IModeloService, ModeloService>(Lifestyle.Scoped);
        }

        private static void Application(Container container)
        {
            Assembly[] assemblies = { typeof(IPatrimonioApplication).Assembly };
            container.Register(typeof(IBaseApplication<>), assemblies, Lifestyle.Scoped);

            container.Register<IPatrimonioApplication, PatrimonioApplication>(Lifestyle.Scoped);
            container.Register<IMarcaApplication, MarcaApplication>(Lifestyle.Scoped);
            container.Register<IModeloApplication, ModeloApplication>(Lifestyle.Scoped);
        }
    }
}