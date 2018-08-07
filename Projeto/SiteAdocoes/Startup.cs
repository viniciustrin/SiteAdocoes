using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SiteAdocoes.Startup))]
namespace SiteAdocoes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
