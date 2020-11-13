using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AIJIA.Startup))]
namespace AIJIA
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
