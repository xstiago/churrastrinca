using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ChurrasTrinca.Startup))]
namespace ChurrasTrinca
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
