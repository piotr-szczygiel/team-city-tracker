using System.Collections.Generic;

namespace TeamCityTracker.Console.Model.ConsoleTable
{
    public class ConsoleTable
    {
        public ConsoleTableRow Headers { get; set; }

        public IEnumerable<ConsoleTableRow> Data { get; set; }
    }
}