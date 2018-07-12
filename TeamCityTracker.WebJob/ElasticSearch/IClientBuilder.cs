using Nest;

namespace TeamCityTracker.WebJob.ElasticSearch
{
    public interface IClientBuilder
    {
        ElasticClient GetClient();
    }
}