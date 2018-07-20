using System.Linq;
using Autofac;
using TeamCityTracker.Console.Operation;
using TeamCityTracker.Console.ProgramOptions;
using TeamCityTracker.Console.TableRenderer;

namespace TeamCityTracker.Console
{
    public class Program
    {
        private static IContainer Container;

        public static void Main(string[] args)
        {
            Bootstraper.Build();
            Container = Bootstraper.Container;
            var programOptions = Container.Resolve<IProgramOptions>();
            var runApp = true;

            while (runApp)
            {
                System.Console.WriteLine("\nSelect an option:\n");
                foreach (var programOption in programOptions.GetOptions())
                {
                    System.Console.WriteLine($"[{programOption.Abbrev}] {programOption.Label}");
                }
                System.Console.WriteLine();

                var userChoice = System.Console.ReadLine();
                var option = programOptions.GetOptions().FirstOrDefault(o => o.Abbrev == userChoice?.ToUpper());

                if (option == null)
                {
                    runApp = false;
                    System.Console.WriteLine("Choosed option doesn't exist. App will close now.");
                    System.Console.ReadLine();
                }
                else
                {
                    ExecuteOperation(option.ConsoleOperation);
                }
            }
        }

        private static void ExecuteOperation(IOperation operation)
        {
            var tableRenderer = Container.Resolve<ITableRenderer>();
            tableRenderer.Render(operation.Execute());
        }
    }
}
