using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Divers_Hotel.Startup))]
namespace Divers_Hotel
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
