using System.Collections.Generic;
using TeamCityTracker.Console.Model.ConsoleTable;

namespace TeamCityTracker.Console.Operation
{
    public abstract class BuildOperation : IOperation
    {
        public abstract ConsoleTable Execute();

        public ConsoleTableRow GetHeaderRow()
        {
            var row = new ConsoleTableRow
            {
                Cells = new[]
                {
                    new ConsoleTableCell("Build name"),
                    new ConsoleTableCell("Executed"),
                    new ConsoleTableCell("Success"),
                    new ConsoleTableCell("Failure"),
                    new ConsoleTableCell("Fail percentage")
                }
            };

            return row;
        }
    }
}