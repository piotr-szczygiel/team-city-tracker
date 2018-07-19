using System;
using System.Threading.Tasks;
using Autofac;
using TeamCityTracker.WebJob.ElasticSearch;
using TeamCityTracker.WebJob.TeamCityApiReader;

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
            var apiReader = Bootstraper.Container.Resolve<ITeamCityApiReader>();
            var repository = Bootstraper.Container.Resolve<IBuildRepository>();

            var builds = await apiReader.GetBuilds().ConfigureAwait(false);
            repository.LoadData(builds.Build);
        }
    }
}