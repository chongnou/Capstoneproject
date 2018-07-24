using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Capstoneproject.Startup))]
namespace Capstoneproject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
