using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InvestorUniverse.Startup))]
namespace InvestorUniverse
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
