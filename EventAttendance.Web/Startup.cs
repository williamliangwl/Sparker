using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EventAttendance.Web.Startup))]
namespace EventAttendance.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
