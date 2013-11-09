using System.Web.Http;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Microsoft.Owin.Hosting;
using Owin;
using System;

namespace Notifications.Core.Server
{
    public class Startup
    {
        public static IDisposable Start()
        {
            var config =
                (ServerConfigurationSection) System.Configuration.ConfigurationManager.GetSection("notificationHub");

            var server = new Server();
            
            var url = string.Format("http://{0}:{1}", config.Host, config.Port);
            server.AddServer(WebApp.Start(url, Configuration));

            return server;
        }

        public static void Configuration(IAppBuilder app)
        {
            // Web API
            var webApiConfig = new HttpConfiguration();
            webApiConfig.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new { id = RouteParameter.Optional });

            app.UseWebApi(webApiConfig);

            // SignalR
            app.Map("/signalr", map =>
            {
                map.UseCors(CorsOptions.AllowAll);

                var hubConfiguration = new HubConfiguration
                {
                    EnableJSONP = true
                };

                map.RunSignalR(hubConfiguration);
            });
        }
    }
}
