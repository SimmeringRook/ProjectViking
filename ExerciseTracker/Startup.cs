using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ExerciseTracker.Startup))]
namespace ExerciseTracker
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
