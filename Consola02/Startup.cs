using Gate.Adapters.Nancy;
using Gate.Middleware;
using Owin;

namespace Consola02
{
    public static class Startup
    {
        public static void Configuration(IAppBuilder builder)
        {
            builder
                .RunNancy();
        }

        public static void Debug(IAppBuilder builder)
        {
            builder
                .UseShowExceptions()
                .RunNancy();
        }
    }
}
