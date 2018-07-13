using System.Net.Http;
using Autofac;
using TeamCityTracker.Common;

namespace TeamCityTracker.WebJob
{
    public class Bootstraper
    {
        public static IContainer Container;

        public static void Bootstrap()
        {
            var builder = new ContainerBuilder();

            // register modules
            builder.RegisterModule<CommonModule>();

            // register domain related types
            builder.RegisterType<HttpClient>().AsSelf().SingleInstance();
            builder.RegisterType<ApiReader.ApiReader>().AsImplementedInterfaces();
            builder.RegisterType<AuthorizationProvider.AuthorizationProvider>().AsImplementedInterfaces();
            builder.RegisterType<HttpClientBuilder.HttpClientBuilder>().AsImplementedInterfaces();
            builder.RegisterType<AppSettings>().AsImplementedInterfaces();

            Bootstraper.Container = builder.Build();
        }
    }
}
