using Autofac;

namespace TeamCityTracker.WebJob
{
    public class Bootstraper
    {
        public static IContainer Container;

        public static void Bootstrap()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<ApiReader.ApiReader>().AsImplementedInterfaces();

            Bootstraper.Container = builder.Build();
        }
    }
}
