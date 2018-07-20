using TeamCityTracker.Console.Model.ConsoleTable;

namespace TeamCityTracker.Console.Operation
{
    public interface IOperation
    {
        ConsoleTable Execute();
    }
}