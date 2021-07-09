using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using ON.Web.Api;
using Owin;
using Schulung.Core.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Schulung.Server
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      FrameworkConfiguration(app);
      WebApiConfiguration(app);
    }

    private static void WebApiConfiguration(IAppBuilder app)
    {
      var config = new OnWebApiConfiguration
      {
        SwaggerEnabled = true,
        JsonSerializerSettings = new JsonSerializerSettings
        {
          NullValueHandling = NullValueHandling.Ignore,
          DateTimeZoneHandling = DateTimeZoneHandling.Utc,
          ContractResolver = new CamelCasePropertyNamesContractResolver()
        },
        MapHttpAttributeRoutes = true,
        Assemblies = new[]
        {
          typeof(Startup).Assembly,
          typeof(ON.Tools.ClientGenerator.Angular.AngularController).Assembly
        }
      };

      app.CreatePerOwinContext(SchulungDbContext.Create);

      app.UseOnWebApi(config);
    }

    static void FrameworkConfiguration(IAppBuilder app)
    {
      var config = new FrameworkConfiguration
      {
        SwaggerEnabled = true,
        EnableSanitizeValidator = true,
      };

      app.UseFramework(config);
    }
  }
}
