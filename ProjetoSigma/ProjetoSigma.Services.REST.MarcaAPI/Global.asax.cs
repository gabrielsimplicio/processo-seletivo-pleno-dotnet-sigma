using System.Web.Http;
using ProjetoSigma.Application.AutoMapper;

namespace ProjetoSigma.Services.REST.MarcaAPI
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            AutoMapperConfig.Register();
        }
    }
}
