using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Go_Print_YourSelf.Startup))]
namespace Go_Print_YourSelf
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
