using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(LibreriaCeibaWebAppB43478.Startup))]
namespace LibreriaCeibaWebAppB43478
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
