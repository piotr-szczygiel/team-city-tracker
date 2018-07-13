using System.Configuration;
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

            builder.RegisterModule<CommonModule>();

            builder.RegisterType<HttpClient>().AsSelf().SingleInstance();
            builder.RegisterType<ApiReader.ApiReader>().AsImplementedInterfaces();
            builder.RegisterType<AuthorizationProvider.AuthorizationProvider>().AsImplementedInterfaces();
            builder.RegisterType<HttpClientBuilder.HttpClientBuilder>().AsImplementedInterfaces();
            builder.RegisterType<AppSettingsReader>().AsSelf();

            Bootstraper.Container = builder.Build();
        }
    }
}
