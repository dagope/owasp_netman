using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(A7.Startup))]
namespace A7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
