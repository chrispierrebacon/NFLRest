using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NFLMVC.Startup))]
namespace NFLMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
