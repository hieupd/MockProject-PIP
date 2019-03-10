using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MockProject_PIP.Startup))]
namespace MockProject_PIP
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
