using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RetailAdvertisingTool.Startup))]
namespace RetailAdvertisingTool
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
