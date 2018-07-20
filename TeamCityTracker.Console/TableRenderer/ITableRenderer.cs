using TeamCityTracker.Console.Model.ConsoleTable;

namespace TeamCityTracker.Console.TableRenderer
{
    public interface ITableRenderer
    {
        void Render(ConsoleTable consoleTable);
    }
}