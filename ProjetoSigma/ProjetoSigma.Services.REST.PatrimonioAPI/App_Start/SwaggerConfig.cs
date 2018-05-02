using System;
using System.Web.Http;
using WebActivatorEx;
using ProjetoSigma.Services.REST.PatrimonioAPI;
using Swashbuckle.Application;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ProjetoSigma.Services.REST.PatrimonioAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "ProjetoSigma.Services.REST.PatrimonioAPI");
                        c.IncludeXmlComments(GetPathXml());
                    })
                .EnableSwaggerUi(c =>
                    {

                    });
        }

        private static string GetPathXml()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"bin\ProjetoSigma.Services.REST.PatrimonioAPI.xml";
        }
    }
}
