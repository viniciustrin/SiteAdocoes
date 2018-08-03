using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Adocoes.Startup))]
namespace Adocoes
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
