using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCProject_1280293.Startup))]
namespace MVCProject_1280293
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
