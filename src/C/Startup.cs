using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(C.Startup))]
namespace C
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
