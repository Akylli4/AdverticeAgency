using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AdverticeAgency.Startup))]
namespace AdverticeAgency
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
