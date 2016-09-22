using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PHCWebApplication.Startup))]
namespace PHCWebApplication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
