using System;
using System.Threading.Tasks;
using Autofac;
using TeamCityTracker.WebJob.ApiReader;
using TeamCityTracker.WebJob.ElasticSearch;

namespace TeamCityTracker.WebJob
{
    internal class Program
    {
        public static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            Bootstraper.Bootstrap();
            var apiReader = Bootstraper.Container.Resolve<IApiReader>();
            var dataLoader = Bootstraper.Container.Resolve<IDataLoader>();

            var builds = await apiReader.GetBuilds().ConfigureAwait(false);
            await dataLoader.Load(builds.Build).ConfigureAwait(false);

            Console.WriteLine("Data loaded.");
        }
    }
}