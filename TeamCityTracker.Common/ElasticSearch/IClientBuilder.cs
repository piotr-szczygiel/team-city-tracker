namespace TeamCityTracker.Common.ElasticSearch
{
    public interface IClientBuilder
    {
        Nest.ElasticClient GetClient();
    }
}