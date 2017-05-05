using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ElectroLED.App.Startup))]
namespace ElectroLED.App
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
