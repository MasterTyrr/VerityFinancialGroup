using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Johns_WebPage.Startup))]
namespace Johns_WebPage
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
