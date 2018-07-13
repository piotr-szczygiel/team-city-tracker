using Nest;

namespace TeamCityTracker.Common.ElasticSearch
{
    public interface IClientBuilder
    {
        ElasticClient GetClient();
    }
}