using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Exam_2016.Startup))]
namespace Exam_2016
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}
