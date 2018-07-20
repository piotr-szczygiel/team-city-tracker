using System.Collections.Generic;

namespace TeamCityTracker.Console.Model.ConsoleTable
{
    public class ConsoleTableRow
    {
        public IEnumerable<ConsoleTableCell> Cells { get; set; }
    }
}