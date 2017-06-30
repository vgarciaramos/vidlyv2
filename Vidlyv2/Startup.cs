using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vidlyv2.Startup))]
namespace Vidlyv2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
