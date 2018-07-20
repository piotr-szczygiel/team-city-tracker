using System.Collections.Generic;
using TeamCityTracker.Console.Model;
using TeamCityTracker.Console.Model.ConsoleTable;

namespace TeamCityTracker.Console.BuildsTableRowParser
{
    public interface IBuildsTableRowParser
    {
        IEnumerable<ConsoleTableRow> Parse(BuildSearchResponse buildSearchResponse);
    }
}