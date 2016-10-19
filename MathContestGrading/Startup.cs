using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MathContestGrading.Startup))]
namespace MathContestGrading
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
