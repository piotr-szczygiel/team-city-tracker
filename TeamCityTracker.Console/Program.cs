using System;
using Autofac;
using ConsoleTables;
using TeamCityTracker.Console.ElasticSearch;
using TeamCityTracker.Console.Model;

namespace TeamCityTracker.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Bootstraper.Build();
            var repository = Bootstraper.Container.Resolve<IBuildRepository>();

            var failingBuilds = repository.GetMostFailingBuilds();
            DisplayMostFailingBuilds(failingBuilds);

            System.Console.ReadLine();
        }

        private static void DisplayMostFailingBuilds(BuildSearchResponse failingBuilds)
        {
            var table = new ConsoleTable("Build name", "Executed", "Success", "Failure", "Fail percentage");
            foreach (var buildInfo in failingBuilds.Builds)
            {
                table.AddRow(buildInfo.BuildIdentifier, buildInfo.Executed, buildInfo.Succeed, buildInfo.Failed,
                    Math.Round(buildInfo.FailurePercentage, 2));
            }

            table.Write();
        }
    }
}
