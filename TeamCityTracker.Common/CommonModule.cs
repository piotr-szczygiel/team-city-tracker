using Autofac;
using TeamCityTracker.Common.ElasticSearch;

namespace TeamCityTracker.Common
{
    public class CommonModule : Module
    {      
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<ClientBuilder>().AsImplementedInterfaces();
            builder.RegisterType<ElasticClient>().AsImplementedInterfaces();
        }
    }
}
