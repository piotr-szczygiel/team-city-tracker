using System;
using System.Collections.Generic;
using System.Linq;
using TeamCityTracker.Console.Model;
using TeamCityTracker.Console.Model.ConsoleTable;

namespace TeamCityTracker.Console.BuildsTableRowParser
{
    public class BuildsTableRowParser : IBuildsTableRowParser
    {
        public IEnumerable<ConsoleTableRow> Parse(BuildSearchResponse buildSearchResponse)
        {
            var rows = buildSearchResponse.Builds.Select(b => new ConsoleTableRow()
            {
                Cells = new[]
                {
                    new ConsoleTableCell(b.BuildIdentifier),
                    new ConsoleTableCell(b.Executed.ToString()), 
                    new ConsoleTableCell(b.Succeed.ToString()), 
                    new ConsoleTableCell(b.Failed.ToString()), 
                    new ConsoleTableCell($"{Math.Round(b.FailurePercentage, 2)} %"), 
                }
            });
            return rows;
        }
    }
}