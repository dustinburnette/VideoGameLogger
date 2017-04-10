using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VideoGameLogger.Startup))]
namespace VideoGameLogger
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
