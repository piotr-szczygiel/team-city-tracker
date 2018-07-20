using System.Linq;
using TeamCityTracker.Console.Model.ConsoleTable;

namespace TeamCityTracker.Console.TableRenderer
{
    public class TableRenderer : ITableRenderer
    {
        public void Render(ConsoleTable consoleTable)
        {
            var table = new ConsoleTables.ConsoleTable(consoleTable.Headers.Cells.Select(c => c.Value).ToArray());
            foreach (var row in consoleTable.Data)
            {
                table.AddRow(row.Cells.Select(c => c.Value).ToArray<object>());
            }

            table.Write();
        }
    }
}