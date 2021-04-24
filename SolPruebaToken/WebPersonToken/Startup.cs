using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebPersonToken.Startup))]
namespace WebPersonToken
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
