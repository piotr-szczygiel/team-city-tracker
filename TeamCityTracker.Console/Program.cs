using Autofac;
using ConsoleTables;
using TeamCityTracker.Common.Model;
using IElasticClient = TeamCityTracker.Common.ElasticSearch.IElasticClient;

namespace TeamCityTracker.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bootstraper.Build();
            var elasticClient = Bootstraper.Container.Resolve<IElasticClient>();

            var failingBuilds = elasticClient.GetMostFailingBuilds();
            DisplayMostFailingBuilds(failingBuilds);

            System.Console.ReadLine();
        }

        private static void DisplayMostFailingBuilds(BuildSearchResponse failingBuilds)
        {
            var table = new ConsoleTable("Build name", "Executed", "Success", "Failure", "Fail percentage");
            foreach (var buildInfo in failingBuilds.Builds)
            {
                table.AddRow(buildInfo.BuildIdentifier, buildInfo.TimesExecuted, buildInfo.TimesSuccessed, buildInfo.TimesFailed, buildInfo.FailurePercentage);
            }

            table.Write();
        }
    }
}
