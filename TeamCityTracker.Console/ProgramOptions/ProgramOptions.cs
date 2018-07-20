using System.Collections.Generic;
using TeamCityTracker.Console.Model;
using TeamCityTracker.Console.Operation;

namespace TeamCityTracker.Console.ProgramOptions 
{
    public class ProgramOptions : IProgramOptions
    {
        private readonly GetBuildTopFailuresOperation getBuildTopFailuresOperation;

        public ProgramOptions(GetBuildTopFailuresOperation getBuildTopFailuresOperation)
        {
            this.getBuildTopFailuresOperation = getBuildTopFailuresOperation;
        }

        public IEnumerable<ProgramOption> GetOptions()
        {
            return new[]
            {
                new ProgramOption("A", "Builds - by failures", this.getBuildTopFailuresOperation)
/*            new ProgramOption("B", "Builds - by succeses"),
            new ProgramOption("C", "Builds - by execution"),*/
            };
        }
    }
}