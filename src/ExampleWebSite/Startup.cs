using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExampleWebSite.Startup))]
namespace ExampleWebSite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
