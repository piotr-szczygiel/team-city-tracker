
using Autofac;
using TeamCityTracker.WebJob.ApiReader;

namespace TeamCityTracker.WebJob
{
    internal class Program
    {
        public static void Main()
        {
            Bootstraper.Bootstrap();
            var apiReader = Bootstraper.Container.Resolve<IApiReader>();
            var builds = apiReader.GetBuilds();
        }
    }
}