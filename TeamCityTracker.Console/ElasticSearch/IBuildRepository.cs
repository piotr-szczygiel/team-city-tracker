using TeamCityTracker.Console.Model;

namespace TeamCityTracker.Console.ElasticSearch
{
    public interface IBuildRepository
    {
        BuildSearchResponse GetMostFailingBuilds();
    }
}