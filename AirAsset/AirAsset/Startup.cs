using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AirAsset.Startup))]
namespace AirAsset
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
