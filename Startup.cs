﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Cors;
using System.Configuration;


using Microsoft.Owin.Security;
using System.Web.Http;

using System.Net.Http.Formatting;
using System.Linq;

using Newtonsoft.Json.Serialization;
using LPAppService.Filters;


[assembly: OwinStartup(typeof(LPAppService.Startup))]

namespace LPAppService
{
    public class Startup
    {
       
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
           
            HttpConfiguration appconfig = new HttpConfiguration();
           
            ConfigureWebApi(appconfig);
           
            app.UseWebApi(appconfig);
          
         
        }
        private void ConfigureWebApi(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                  name: "DefaultApi",
                  routeTemplate: "api/{controller}/{id}",
                  defaults: new { id = RouteParameter.Optional }
              );
            config.Filters.Add(new LPAppService.Filters.ValidateModelAttribute());
            config.Filters.Add(new LPAppService.Filters.ExceptionHandlingAttribute());

            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().First();
            jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();

        }


     
    }
}
