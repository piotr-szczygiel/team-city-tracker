using Autofac;
using TeamCityTracker.Common;

namespace TeamCityTracker.Console
{
    public class Bootstraper
    {
        public static IContainer Container;

        public static void Build()
        {
            var builder = new ContainerBuilder();

            // register modules
            builder.RegisterModule<CommonModule>();

            // register domain related types
            builder.RegisterType<AppSettings>().AsImplementedInterfaces().SingleInstance();


            Container = builder.Build();
        }
    }
}