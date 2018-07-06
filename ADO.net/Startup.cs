using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ADO.net.Startup))]
namespace ADO.net
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
