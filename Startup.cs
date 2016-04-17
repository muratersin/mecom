using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Mecom.Startup))]
namespace Mecom
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
