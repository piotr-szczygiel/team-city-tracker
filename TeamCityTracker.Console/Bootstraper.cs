using Autofac;
using TeamCityTracker.Common;
using TeamCityTracker.Console.BuildsTableRowParser;
using TeamCityTracker.Console.ElasticSearch;
using TeamCityTracker.Console.Operation;

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
            builder.RegisterType<BuildRepository>().AsImplementedInterfaces();
            builder.RegisterType<BuildsTableRowParser.BuildsTableRowParser>().AsImplementedInterfaces();
            builder.RegisterType<TableRenderer.TableRenderer>().AsImplementedInterfaces().SingleInstance();

            // console operations
            builder.RegisterType<ProgramOptions.ProgramOptions>().AsImplementedInterfaces();
            builder.RegisterType<GetBuildTopFailuresOperation>().AsSelf();

            Container = builder.Build();
        }
    }
}