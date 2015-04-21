using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TestUIGridBasics.Startup))]
namespace TestUIGridBasics
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
