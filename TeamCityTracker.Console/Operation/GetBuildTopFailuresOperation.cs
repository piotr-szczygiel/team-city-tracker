using TeamCityTracker.Console.BuildsTableRowParser;
using TeamCityTracker.Console.ElasticSearch;
using TeamCityTracker.Console.Model.ConsoleTable;

namespace TeamCityTracker.Console.Operation
{
    public class GetBuildTopFailuresOperation : BuildOperation
    {
        private readonly IBuildRepository repository;
        private readonly IBuildsTableRowParser buildsTableRowParser;

        public GetBuildTopFailuresOperation(IBuildRepository repository, IBuildsTableRowParser buildsTableRowParser)
        {
            this.repository = repository;
            this.buildsTableRowParser = buildsTableRowParser;
        }

        public override ConsoleTable Execute()
        {
            var failingBuilds = repository.GetMostFailingBuilds();

            var consoleTable = new ConsoleTable
            {
                Headers = this.GetHeaderRow(),
                Data = this.buildsTableRowParser.Parse(failingBuilds)
            };

            return consoleTable;
        }
    }
}