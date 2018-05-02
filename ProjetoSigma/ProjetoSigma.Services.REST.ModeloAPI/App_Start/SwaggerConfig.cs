using System.Web.Http;
using WebActivatorEx;
using ProjetoSigma.Services.REST.ModeloAPI;
using Swashbuckle.Application;
using System;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ProjetoSigma.Services.REST.ModeloAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "ProjetoSigma.Services.REST.ModeloAPI");
                        c.IncludeXmlComments(GetPathXml());
                    })
                .EnableSwaggerUi(c =>
                    {

                    });
        }

        private static string GetPathXml()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"bin\ProjetoSigma.Services.REST.ModeloAPI.xml";
        }
    }
}
