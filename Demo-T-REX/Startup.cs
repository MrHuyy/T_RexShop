using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Demo_T_REX.Startup))]
namespace Demo_T_REX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
