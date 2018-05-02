using System.Web.Http;
using WebActivatorEx;
using ProjetoSigma.Services.REST.MarcaAPI;
using Swashbuckle.Application;
using System;
using System.Xml.XPath;

[assembly: PreApplicationStartMethod(typeof(SwaggerConfig), "Register")]

namespace ProjetoSigma.Services.REST.MarcaAPI
{
    public class SwaggerConfig
    {
        public static void Register()
        {
            var thisAssembly = typeof(SwaggerConfig).Assembly;

            GlobalConfiguration.Configuration
                .EnableSwagger(c =>
                    {
                        c.SingleApiVersion("v1", "ProjetoSigma.Services.REST.MarcaAPI");
                        c.IncludeXmlComments(GetPathXml());
                    })
                .EnableSwaggerUi(c =>
                    {
  
                    });
        }

        private static string GetPathXml()
        {
            return AppDomain.CurrentDomain.BaseDirectory + @"bin\ProjetoSigma.Services.REST.MarcaAPI.xml";
        }
    }
}
