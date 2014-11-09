using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TapestryWorld.Web.Startup))]
namespace TapestryWorld.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
