using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Udemy_VidlyApp.Startup))]
namespace Udemy_VidlyApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
