using TeamCityTracker.Common.Model;

namespace TeamCityTracker.Console.ElasticSearch
{
    public interface IBuildRepository
    {
        BuildSearchResponse GetMostFailingBuilds();
    }
}