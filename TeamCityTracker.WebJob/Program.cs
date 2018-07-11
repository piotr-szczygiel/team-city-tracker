using System.Threading.Tasks;
using Autofac;
using TeamCityTracker.WebJob.ApiReader;

namespace TeamCityTracker.WebJob
{
    internal class Program
    {
        public static void Main()
        {
            MainAsync().GetAwaiter().GetResult();
        }

        private static async Task MainAsync()
        {
            Bootstraper.Bootstrap();
            var apiReader = Bootstraper.Container.Resolve<IApiReader>();
            var builds = await apiReader.GetBuilds().ConfigureAwait(false);
        }
    }
}