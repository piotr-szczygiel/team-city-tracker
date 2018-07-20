using TeamCityTracker.Console.Operation;

namespace TeamCityTracker.Console.Model
{
    public class ProgramOption
    {
        public string Abbrev { get; set; }

        public string Label { get; set; }

        public IOperation ConsoleOperation { get; set; }

        public ProgramOption(string abbrev, string label, IOperation operation)
        {
            this.Abbrev = abbrev;
            this.Label = label;
            this.ConsoleOperation = operation;
        }
    }
}